using Riot.NET.Attributes;
using Riot.NET.Endpoints.SummonerV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.SummonerV4.Methods;

[Path("/summoners/me")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
[Summary("Get account by access token.")]
public class GetSummonerByAccessToken(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionAccessTokenMethodBase<SummonerDTO>(endpoint, rateLimiter)
{
}