using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LolChallengesV1.Methods;

[Path("/challenges/{0}/percentiles")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetChallengePercentiles(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<Dictionary<Tier, double>>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public long ChallengeId { get; set; }
}