using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.LorStatusV1;

[Endpoint("/lor/status/v1")]
public partial class LorStatusV1(RateLimiter.RateLimiter rateLimiter)
{
}