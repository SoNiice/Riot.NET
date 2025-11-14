using Riot.NET.Attributes;
using Riot.NET.Endpoints.SpectatorV5.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.SpectatorV5.Methods;

[Path("/active-games/by-summoner/{0}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetActiveGame(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<CurrentGameInfo>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Puuid { get; set; } = string.Empty;
}