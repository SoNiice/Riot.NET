using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.TournamentStubV5;

[Endpoint("/lol/tournament-stub/v5")]
public partial class TournamentStubV5(RateLimiter.RateLimiter rateLimiter)
{
}