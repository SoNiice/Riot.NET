using Riot.NET.Attributes;
using Riot.NET.Endpoints.ClashV1.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.ClashV1.Methods;

[Path("/tournaments")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetTournaments(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<List<TournamentDTO>>(endpoint, rateLimiter)
{
}