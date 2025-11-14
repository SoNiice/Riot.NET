using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.LolChallengesV1;

[Endpoint("/lol/challenges/v1")]
public partial class LolChallengesV1(RateLimiter.RateLimiter rateLimiter)
{
}