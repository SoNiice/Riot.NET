using System.ComponentModel;
using Riot.NET.Attributes;
using Riot.NET.Endpoints.ChampionMasteryV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.ChampionMasteryV4.Methods;

[Path("/champion-masteries/by-puuid/{0}/top?count={1}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetTopChampionMasteriesByPuuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<List<ChampionMasteryDTO>>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Puuid { get; set; } = string.Empty;

    [RequestParameter(1)]
    [DefaultValue(3)]
    public int Count { get; set; }
}