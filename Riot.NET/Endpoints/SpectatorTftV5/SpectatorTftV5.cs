using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.SpectatorTftV5;

[Endpoint("/lol/spectator/tft/v5")]
public partial class SpectatorTftV5(RateLimiter.RateLimiter rateLimiter)
{
}