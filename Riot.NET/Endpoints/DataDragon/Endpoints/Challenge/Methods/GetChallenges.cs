using Riot.NET.Attributes;
using Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Methods;

[Path("/challenges.json")]
public class GetChallenges(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonDataMethodBase<List<ChallengeDTO>>(endpoint, rateLimiter)
{
}