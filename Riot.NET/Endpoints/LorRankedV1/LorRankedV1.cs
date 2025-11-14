using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.LorRankedV1;

[Endpoint("/lor/ranked/v1")]
public partial class LorRankedV1(RateLimiter.RateLimiter rateLimiter)
{
}