using Riot.NET.Attributes;
using Riot.NET.Endpoints.LeagueV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LeagueV4.Methods;

[Path("/entries/{0}/{1}/{2}")]
[RateLimit(TimeUnit.Seconds, 10, 50)]
public class GetEntries(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<List<LeagueEntryDTO>>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public Queue Queue { get; set; }
    [RequestParameter(1)] public Tier Tier { get; set; }
    [RequestParameter(2)] public Division Division { get; set; }
}