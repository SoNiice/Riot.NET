using Riot.NET.Attributes;
using Riot.NET.Endpoints.LeagueV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LeagueV4.Methods;

[Path("/entries/by-summoner/{0}")]
[RateLimit(TimeUnit.Minutes, 1, 100)]
public class GetEntriesBySummoner(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<List<LeagueEntryDTO>>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string SummonerId { get; set; } = string.Empty;
}