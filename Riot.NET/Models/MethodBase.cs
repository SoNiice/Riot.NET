using Newtonsoft.Json;
using Riot.NET.Attributes;
using Riot.NET.Extensions;
using Riot.NET.Interfaces;

namespace Riot.NET.Models;

public abstract class MethodBase<TResponse>(string endpoint, RateLimiter.RateLimiter rateLimiter) : IMethod<TResponse> where TResponse : new()
{
    protected readonly string Endpoint = endpoint;
    protected readonly RateLimiter.RateLimiter RateLimiter = rateLimiter;

    public string Url => Endpoint + GetPathUri();

    protected string GetPathUri()
    {
        return GetType().GetPath();
    }

    protected HttpMethod GetPathMethod()
    {
        return GetType().GetMethod();
    }

    public virtual async Task<TResponse> ExecuteAsync()
    {
        var accessToken = GetAccessToken();
        var (region, formattedUrl) = FormatUrlAndGetRegion();
        var body = FormatBody();

        var response = await RateLimiter.SendAsync(GetPathMethod(), region, Url, formattedUrl, body, accessToken);
        var json = await response.Content.ReadAsStringAsync();

        return DeserializeResponse(json);
    }

    public virtual TResponse Execute()
    {
        var accessToken = GetAccessToken();
        var (region, formattedUrl) = FormatUrlAndGetRegion();
        var body = FormatBody();

        var response = RateLimiter.Send(GetPathMethod(), region, Url, formattedUrl, body, accessToken);
        var receiveStream = response.Content.ReadAsStream();
        var readStream = new StreamReader(receiveStream);
        var json = readStream.ReadToEnd();

        return DeserializeResponse(json);
    }

    protected virtual TResponse DeserializeResponse(string json)
    {
        if (string.IsNullOrEmpty(json))
            return new TResponse();

        return JsonConvert.DeserializeObject<TResponse>(json) ?? new TResponse();
    }

    protected virtual string GetAccessToken()
    {
        return string.Empty;
    }

    protected virtual string FormatBody()
    {
        return string.Empty;
    }

    protected abstract (string region, string formattedUrl) FormatUrlAndGetRegion();
}