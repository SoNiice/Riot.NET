using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.SpectatorV5;

[Endpoint("/lol/spectator/v5")]
public partial class SpectatorV5(RateLimiter.RateLimiter rateLimiter)
{
}