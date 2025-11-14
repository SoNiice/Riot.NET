using Riot.NET.Attributes;
using Riot.NET.Endpoints.LolChallengesV1.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LolChallengesV1.Methods;

[Path("/player-data/{0}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetPlayerData(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<PlayerInfoDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Puuid { get; set; } = string.Empty;
}