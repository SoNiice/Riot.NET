using Riot.NET.Attributes;
using Riot.NET.Endpoints.LorRankedV1.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.LorRankedV1.Methods;

[Path("/leaderboards")]
public class GetLeaderboards(string endpoint, RateLimiter.RateLimiter rateLimiter) : ShardMethodBase<LeaderboardDTO>(endpoint, rateLimiter)
{
}