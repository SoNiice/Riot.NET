using System.ComponentModel;
using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.TournamentV5.Methods;

[Path("/providers", "POST")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class CreateProvider(string endpoint, RateLimiter.RateLimiter rateLimiter) : StaticShardMethodBase<int>(Shard.Americas, endpoint, rateLimiter)
{
    [BodyParameter(0)] public Region Region { get; set; }
    [BodyParameter(1)] public string Url { get; set; } = string.Empty;
}