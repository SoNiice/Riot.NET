using Riot.NET.Attributes;
using Riot.NET.Endpoints.ClashV1.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.ClashV1.Methods;

[Path("/tournaments/by-team/{0}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetTournamentByTeam(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<TournamentDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string TeamId { get; set; } = string.Empty;
}