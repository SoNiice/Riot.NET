using Riot.NET.Attributes;
using Riot.NET.Endpoints.AccountV1.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.AccountV1.Methods;

[Path("/region/by-game/{0}/by-puuid/{1}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
[Summary("Get active region for a <see cref=\"RegionGame\"/>")]
public class GetRegionByPuuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : ShardMethodBase<AccountRegionDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public RegionGame Game { get; set; }
    [RequestParameter(1)] public string Puuid { get; set; } = string.Empty;
}