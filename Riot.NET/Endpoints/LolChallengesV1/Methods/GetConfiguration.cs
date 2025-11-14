using Riot.NET.Attributes;
using Riot.NET.Endpoints.LolChallengesV1.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LolChallengesV1.Methods;

[Path("/challenges/{0}/config")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetConfiguration(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<ChallengeConfigInfoDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public long ChallengeId { get; set; }
}