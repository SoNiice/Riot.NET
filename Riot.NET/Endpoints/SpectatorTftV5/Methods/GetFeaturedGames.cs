using Riot.NET.Attributes;
using Riot.NET.Endpoints.SpectatorTftV5.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.SpectatorTftV5.Methods;

[Path("/featured-games")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetFeaturedGames(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<FeaturedGames>(endpoint, rateLimiter)
{
}