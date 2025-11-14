using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.ChampionMasteryV4.Methods;

[Path("/scores/by-puuid/{0}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetChampionMasteryScoreByPuuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<int>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Puuid { get; set; } = string.Empty;
}