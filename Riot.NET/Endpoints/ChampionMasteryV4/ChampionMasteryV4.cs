using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.ChampionMasteryV4;

[Endpoint("/lol/champion-mastery/v4")]
public partial class ChampionMasteryV4(RateLimiter.RateLimiter rateLimiter)
{
}