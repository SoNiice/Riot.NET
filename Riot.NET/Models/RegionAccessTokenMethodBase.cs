using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Extensions;

namespace Riot.NET.Models;

public abstract class RegionAccessTokenMethodBase<TResponse>(string endpoint, RateLimiter.RateLimiter rateLimiter) : MethodBase<TResponse>(endpoint, rateLimiter) where TResponse : new()
{
    public Region Region { get; set; }
    public string AccessToken { get; set; } = string.Empty;

    protected override string GetAccessToken()
    {
        return AccessToken;
    }


    protected override (string region, string formattedUrl) FormatUrlAndGetRegion()
    {
        var region = Region.GetRegion();
        var formattedUrl = UrlFormatter.FormatUrl(Url, this);

        return (region, formattedUrl);
    }
}