using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Map;

[Endpoint("/cdn")]
public partial class Map(RateLimiter.RateLimiter rateLimiter)
{
}