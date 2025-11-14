using Riot.NET.Attributes;
using Riot.NET.Endpoints.ChampionMasteryV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.ChampionMasteryV4.Methods;

[Path("/champion-masteries/by-puuid/{0}/by-champion/{1}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetChampionMasteryByPuuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<ChampionMasteryDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Puuid { get; set; } = string.Empty;
    [RequestParameter(1)] public long ChampionId { get; set; }
}