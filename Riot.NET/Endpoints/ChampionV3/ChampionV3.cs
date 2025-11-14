using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.ChampionV3;

[Endpoint("/lol/platform/v3")]
public partial class ChampionV3(RateLimiter.RateLimiter rateLimiter)
{
}