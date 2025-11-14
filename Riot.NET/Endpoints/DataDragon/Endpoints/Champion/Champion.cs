using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion;

[Endpoint("/cdn")]
public partial class Champion(RateLimiter.RateLimiter rateLimiter)
{
}