using Riot.NET.Attributes;
using Riot.NET.Endpoints.LolChallengesV1.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LolChallengesV1.Methods;

[Path("/challenges/{0}/leaderboards/by-level/{1}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetLeaderboards(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<List<ApexPlayerInfoDTO>>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public long ChallengeId { get; set; }
    [RequestParameter(1)] public Tier Level { get; set; }
}