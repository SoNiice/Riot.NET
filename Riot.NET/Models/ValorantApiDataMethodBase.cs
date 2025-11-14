using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Extensions;

namespace Riot.NET.Models;

public abstract class ValorantApiDataMethodBase<TResponse>(string endpoint, RateLimiter.RateLimiter rateLimiter) : MethodBase<TResponse>(endpoint, rateLimiter) where TResponse : new()
{
    public string Language { get; set; } = string.Empty;

    protected override (string region, string formattedUrl) FormatUrlAndGetRegion()
    {
        var formattedUrl = UrlFormatter.FormatStaticUrl(Url, this);

        return (string.Empty, formattedUrl);
    }

    protected override string FormatBody()
    {
        return string.Empty;
    }

    public override async Task<TResponse> ExecuteAsync()
    {
        var (region, formattedUrl) = FormatUrlAndGetRegion();
        var url = formattedUrl + (formattedUrl.Contains('?') ? $"&language={Language.Replace('_', '-')}" : $"?language={Language.Replace('_', '-')}");
        var response = await RateLimiter.SendAsync(HttpMethod.Get, region, "https://valorant-api.com" + url, formattedUrl, string.Empty, false);
        var json = await response.Content.ReadAsStringAsync();

        return DeserializeResponse(json);
    }
}