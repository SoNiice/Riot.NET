using Riot.NET.Attributes;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Version.Methods;

[Path("/versions.json")]
public class GetVersions(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonMethodBase<List<string>>(endpoint, rateLimiter)
{
}