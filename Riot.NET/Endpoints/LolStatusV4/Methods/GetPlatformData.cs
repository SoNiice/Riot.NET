using Riot.NET.Attributes;
using Riot.NET.Endpoints.LolStatusV4.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LolStatusV4.Methods;

[Path("/platform-data")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetPlatformData(string endpoint, RateLimiter.RateLimiter rateLimiter) : RegionMethodBase<PlatformDataDTO>(endpoint, rateLimiter)
{
}