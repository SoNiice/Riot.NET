using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Version;

[Endpoint("/api")]
public partial class Version(RateLimiter.RateLimiter rateLimiter)
{
}