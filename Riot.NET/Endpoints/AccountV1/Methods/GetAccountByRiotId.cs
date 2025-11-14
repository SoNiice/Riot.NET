using Riot.NET.Attributes;
using Riot.NET.Endpoints.AccountV1.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.AccountV1.Methods;

[Path("/accounts/by-riot-id/{0}/{1}")]
[RateLimit(TimeUnit.Minutes, 1, 1000)]
[Summary("Get account by riot id.")]
public class GetAccountByRiotId(string endpoint, RateLimiter.RateLimiter rateLimiter) : ShardMethodBase<AccountDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string GameName { get; set; } = string.Empty;
    [RequestParameter(1)] public string TagLine { get; set; } = string.Empty;
}