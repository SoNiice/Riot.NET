using Riot.NET.Attributes;
using Riot.NET.Endpoints.LeagueV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LeagueV4.Methods;

[Path("/challengerleagues/by-queue/{0}")]
[RateLimit(TimeUnit.Seconds, 10, 30)]
[RateLimit(TimeUnit.Minutes, 10, 500)]
public class GetChallengerLeague(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<LeagueListDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public Queue Queue { get; set; }
}