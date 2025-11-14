using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Challenge;

[Endpoint("/cdn")]
public partial class Challenge(RateLimiter.RateLimiter rateLimiter)
{
}