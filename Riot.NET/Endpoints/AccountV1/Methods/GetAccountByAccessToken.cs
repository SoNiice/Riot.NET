using Riot.NET.Attributes;
using Riot.NET.Endpoints.AccountV1.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.AccountV1.Methods;

[Path("/accounts/me")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
[Summary("Get account by access token.")]
public class GetAccountByAccessToken(string endpoint, RateLimiter.RateLimiter rateLimiter) : StaticShardAccessTokenMethodBase<AccountDTO>(Shard.Americas, endpoint, rateLimiter)
{
}