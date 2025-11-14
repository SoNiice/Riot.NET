using Riot.NET.Attributes;
using Riot.NET.Endpoints.ChampionV3.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.ChampionV3.Methods;

[Path("/champion-rotations")]
[RateLimit(TimeUnit.Seconds, 10, 30)]
[RateLimit(TimeUnit.Minutes, 10, 500)]
public class GetChampionRotations(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<ChampionInfo>(endpoint, rateLimiter)
{
}