using Riot.NET.Attributes;
using Riot.NET.Endpoints.LolChallengesV1.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LolChallengesV1.Methods;

[Path("/challenges/config")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetConfigurations(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<List<ChallengeConfigInfoDTO>>(endpoint, rateLimiter)
{
}