using Riot.NET.Attributes;
using Riot.NET.Endpoints.ChampionMasteryV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.ChampionMasteryV4.Methods;

[Path("/champion-masteries/by-puuid/{0}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetChampionMasteriesByPuuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<ChampionMasteryDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Puuid { get; set; } = string.Empty;
}