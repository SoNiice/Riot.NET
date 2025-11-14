using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.MatchV5;

[Endpoint("/lol/match/v5")]
public partial class MatchV5(RateLimiter.RateLimiter rateLimiter)
{
}