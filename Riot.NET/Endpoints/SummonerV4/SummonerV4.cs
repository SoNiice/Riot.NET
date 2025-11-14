using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.SummonerV4;

[Endpoint("/lol/summoner/v4")]
public partial class SummonerV4(RateLimiter.RateLimiter rateLimiter)
{
}