using Riot.NET.Attributes;
using Riot.NET.Endpoints.MatchV5.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.MatchV5.Methods;

[Path("/matches/{0}/timeline")]
public class GetMatchTimeline(string endpoint, RateLimiter.RateLimiter rateLimiter) : ShardMethodBase<TimeLineDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string MatchId { get; set; } = string.Empty;
}