using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.ClashV1;

[Endpoint("/lol/clash/v1")]
public partial class ClashV1(RateLimiter.RateLimiter rateLimiter)
{
}