using Riot.NET.Attributes;
using Riot.NET.Endpoints.LeagueV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LeagueV4.Methods;

[Path("/entries/{0}/{1}/{2}")]
[RateLimit(TimeUnit.Seconds, 10, 500)]
public class GetLeague(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<LeagueListDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string LeagueId { get; set; } = string.Empty;
}