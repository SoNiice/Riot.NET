using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.LorMatchV1;

[Endpoint("/lor/match/v1")]
public partial class LorMatchV1(RateLimiter.RateLimiter rateLimiter)
{
}