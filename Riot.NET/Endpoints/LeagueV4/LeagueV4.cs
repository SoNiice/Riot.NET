using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.LeagueV4;

[Endpoint("/lol/league/v4")]
public partial class LeagueV4(RateLimiter.RateLimiter rateLimiter)
{
}