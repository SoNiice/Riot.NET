using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.TournamentV5;

[Endpoint("/lol/tournament/v5")]
public partial class TournamentV5(RateLimiter.RateLimiter rateLimiter)
{
}