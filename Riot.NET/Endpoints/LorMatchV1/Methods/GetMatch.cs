using Riot.NET.Attributes;
using Riot.NET.Endpoints.LorMatchV1.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LorMatchV1.Methods;

[Path("/matches/{0}")]
public class GetMatch(string endpoint, RateLimiter.RateLimiter rateLimiter) : ShardMethodBase<MatchDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string MatchId { get; set; } = string.Empty;
}