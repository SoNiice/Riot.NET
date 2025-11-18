using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Extensions;

namespace Riot.NET.Models;

public abstract class RegionMethodBase<TResponse>(string endpoint, RateLimiter.RateLimiter limiter) : MethodBase<TResponse>(endpoint, limiter) where TResponse : new()
{
    public Region Region { get; set; }

    protected override (string region, string formattedUrl) FormatUrlAndGetRegion()
    {
        var region = Region.GetRegion();
        var formattedUrl = UrlFormatter.FormatUrl(Url, this);

        return (region, formattedUrl);
    }
}