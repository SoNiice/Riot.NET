using System.Collections.Concurrent;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Riot.NET.Enums;
using Riot.NET.Extensions;

namespace Riot.NET.RateLimiter;

public enum RateLimitScope
{
    Application,
    Method
}

public class RateLimiter(string apiKey, bool throwOnRateLimit = false, int rateLimitRetryCount = 3)
{
    private readonly HttpClient _httpClient = new();

    private readonly ConcurrentDictionary<string, List<RateLimitRule>> _regionAppLimits = new();
    private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, List<RateLimitRule>>> _regionMethodLimits = new();
    private readonly SemaphoreSlim _requestLock = new(1, 1);

    public void ConfigureRateLimits(Dictionary<TimeSpan, int> applicationRateLimits, Dictionary<RiotMethod, Dictionary<TimeSpan, int>> methodRateLimits)
    {
        var regions = Enum.GetValues<Region>().Select(e => e.GetRegion()).Concat(Enum.GetValues<Shard>().Select(e => e.GetRegion())).Concat([""]);

        foreach (var region in regions)
        {
            ConfigureApplicationLimits(region, applicationRateLimits);

            foreach (var method in methodRateLimits)
                ConfigureMethodLimits(region, method.Key.GetFullPath(), method.Value);
        }
    }

    private void ConfigureApplicationLimits(string region, Dictionary<TimeSpan, int> rules)
    {
        _regionAppLimits[region] = rules.Select(r => new RateLimitRule(r.Key, r.Value)).ToList();
    }

    private void ConfigureMethodLimits(string region, string path, Dictionary<TimeSpan, int> rules)
    {
        if (!_regionMethodLimits.ContainsKey(region))
            _regionMethodLimits[region] = new();

        _regionMethodLimits[region][path] = rules.Select(r => new RateLimitRule(r.Key, r.Value)).ToList();
    }

    public async Task<HttpResponseMessage> SendAsync(
        HttpMethod method,
        string region,
        string url,
        string path,
        string body,
        bool useApplicationLimits = true,
        CancellationToken cancellationToken = default)
    {
        var retryCount = 0;

        while (retryCount < rateLimitRetryCount)
        {
            await _requestLock.WaitAsync(cancellationToken);

            try
            {
                if (useApplicationLimits && _regionAppLimits.TryGetValue(region, out var appRules) && !TryCheckRateLimit(appRules, out var retryApp, out var countApp))
                {
                    if (throwOnRateLimit)
                        throw new RateLimitExceededException(RateLimitScope.Application, region, url, countApp, retryApp);

                    await Task.Delay(retryApp, cancellationToken);
                    retryCount++;
                    continue;
                }

                if (_regionMethodLimits.TryGetValue(region, out var methodRegions) &&
                    methodRegions.TryGetValue(path, out var methodRules) &&
                    !TryCheckRateLimit(methodRules, out var retryMethod, out var countMethod))
                {
                    if (throwOnRateLimit)
                        throw new RateLimitExceededException(RateLimitScope.Method, region, url, countMethod, retryMethod);

                    await Task.Delay(retryMethod, cancellationToken);
                    retryCount++;
                    continue;
                }

                break;
            }
            finally
            {
                _requestLock.Release();
            }
        }

        var request = new HttpRequestMessage(method, string.IsNullOrEmpty(region) ? url : $"https://{region}.api.riotgames.com{path}");
        request.Headers.Add("X-Riot-Token", apiKey);

        if (!string.IsNullOrEmpty(body))
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
            return response;

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            if (response.Headers.TryGetValues("Retry-After", out var values))
            {
                var retryAfter = TimeSpan.FromSeconds(int.Parse(values.First()));

                if (throwOnRateLimit)
                    throw new RateLimitExceededException(RateLimitScope.Method, region, url, -1, retryAfter);

                await Task.Delay(retryAfter, cancellationToken);
                return await SendAsync(method, region, url, path, body, useApplicationLimits, cancellationToken);
            }
        }

        string message;

        try
        {
            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            var obj = JObject.Parse(json);
            message = obj["status"]?["message"]?.ToObject<string>() ?? response.StatusCode.ToString();
        }
        catch
        {
            message = response.StatusCode.ToString();
        }

        throw new RiotException(message, response.StatusCode);
    }

    public HttpResponseMessage Send(
        HttpMethod method,
        string region,
        string url,
        string path,
        string body,
        bool useApplicationLimits = true)
    {
        if (useApplicationLimits && _regionAppLimits.TryGetValue(region, out var appRules) && !TryCheckRateLimit(appRules, out var retryApp, out var countApp))
            throw new RateLimitExceededException(RateLimitScope.Application, region, url, countApp, retryApp);

        if (_regionMethodLimits.TryGetValue(region, out var methodRegions) &&
            methodRegions.TryGetValue(path, out var methodRules) &&
            !TryCheckRateLimit(methodRules, out var retryMethod, out var countMethod))
            throw new RateLimitExceededException(RateLimitScope.Method, region, url, countMethod, retryMethod);

        var request = new HttpRequestMessage(method, string.IsNullOrEmpty(region) ? url : $"https://{region}.api.riotgames.com{path}");
        request.Headers.Add("X-Riot-Token", apiKey);

        if (!string.IsNullOrEmpty(body))
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

        var response = _httpClient.Send(request);

        if (response.IsSuccessStatusCode)
            return response;

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            if (response.Headers.TryGetValues("Retry-After", out var values))
            {
                var retryAfter = TimeSpan.FromSeconds(int.Parse(values.First()));
                throw new RateLimitExceededException(RateLimitScope.Method, region, url, -1, retryAfter);
            }
        }

        string message;

        try
        {
            var receiveStream = response.Content.ReadAsStream();
            var readStream = new StreamReader(receiveStream);
            var json = readStream.ReadToEnd();
            var obj = JObject.Parse(json);
            message = obj["status"]?["message"]?.ToObject<string>() ?? response.StatusCode.ToString();
        }
        catch
        {
            message = response.StatusCode.ToString();
        }

        throw new RiotException(message, response.StatusCode);
    }

    private bool TryCheckRateLimit(List<RateLimitRule> rules, out TimeSpan retryAfter, out int currentCount)
    {
        retryAfter = TimeSpan.Zero;
        currentCount = 0;

        if (rules.Count == 0)
            return true;

        foreach (var rule in rules)
        {
            if (rule.TryConsume(out var retry))
                continue;

            retryAfter = retry;
            currentCount = rules.Sum(r => r.Limit);
            return false;
        }

        return true;
    }
}