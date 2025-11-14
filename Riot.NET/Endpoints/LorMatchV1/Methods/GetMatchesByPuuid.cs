using Riot.NET.Attributes;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LorMatchV1.Methods;

[Path("/matches/by-puuid/{0}/ids")]
public class GetMatchesByPuuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : ShardMethodBase<List<string>>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Id { get; set; } = string.Empty;
}