using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.LolStatusV4;

[Endpoint("/lol/status/v4")]
public partial class LolStatusV4(RateLimiter.RateLimiter rateLimiter)
{
}