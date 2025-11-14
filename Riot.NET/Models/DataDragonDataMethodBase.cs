using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Extensions;

namespace Riot.NET.Models;

public abstract class DataDragonDataMethodBase<TResponse>(string endpoint, RateLimiter.RateLimiter rateLimiter) : MethodBase<TResponse>(endpoint, rateLimiter) where TResponse : new()
{
    public string Version { get; set; } = string.Empty;
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
        var url = Url.Replace("/cdn/", $"/cdn/{Version}/data/{Language}/");
        var response = await RateLimiter.SendAsync(HttpMethod.Get, region, "https://ddragon.leagueoflegends.com" + url, formattedUrl, string.Empty, false);
        var json = await response.Content.ReadAsStringAsync();

        return DeserializeResponse(json);
    }
}