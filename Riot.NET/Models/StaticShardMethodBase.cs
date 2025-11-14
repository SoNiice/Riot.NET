using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Extensions;

namespace Riot.NET.Models;

public abstract class StaticShardMethodBase<TResponse>(Shard shard, string endpoint, RateLimiter.RateLimiter rateLimiter) : MethodBase<TResponse>(endpoint, rateLimiter) where TResponse : new()
{
    protected override (string region, string formattedUrl) FormatUrlAndGetRegion()
    {
        var region = shard.GetRegion();
        var formattedUrl = UrlFormatter.FormatUrl(Url, this);

        return (region, formattedUrl);
    }

    protected override string FormatBody()
    {
        return UrlFormatter.FormatBody(this);
    }
}