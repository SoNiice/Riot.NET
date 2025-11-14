using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.LeagueExpV4;

[Endpoint("/lol/league-exp/v4")]
public partial class LeagueExpV4(RateLimiter.RateLimiter rateLimiter)
{
}