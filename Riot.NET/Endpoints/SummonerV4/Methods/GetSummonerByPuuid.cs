using Riot.NET.Attributes;
using Riot.NET.Endpoints.SummonerV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.SummonerV4.Methods;

[Path("/summoners/by-puuid/{0}")]
[RateLimit(TimeUnit.Minutes, 1, 1600)]
public class GetSummonerByPuuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<SummonerDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Puuid { get; set; } = string.Empty;
}