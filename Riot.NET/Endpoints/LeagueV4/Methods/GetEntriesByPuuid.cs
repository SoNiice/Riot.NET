using Riot.NET.Attributes;
using Riot.NET.Endpoints.LeagueV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LeagueV4.Methods;

[Path("/entries/by-puuid/{0}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetEntriesByPuuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<List<LeagueEntryDTO>>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Puuid { get; set; } = string.Empty;
}