using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Extensions;

namespace Riot.NET.Models;

public abstract class ShardMethodBase<TResponse>(string endpoint, RateLimiter.RateLimiter rateLimiter) : MethodBase<TResponse>(endpoint, rateLimiter) where TResponse : new()
{
    public Shard Shard { get; set; }

    protected override (string region, string formattedUrl) FormatUrlAndGetRegion()
    {
        var region = Shard.GetRegion();
        var formattedUrl = UrlFormatter.FormatUrl(Url, this);

        return (region, formattedUrl);
    }
}