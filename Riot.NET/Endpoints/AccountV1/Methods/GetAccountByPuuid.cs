using Riot.NET.Attributes;
using Riot.NET.Endpoints.AccountV1.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.AccountV1.Methods;

[Path("/accounts/by-puuid/{0}")]
[RateLimit(TimeUnit.Minutes, 1, 1000)]
[Summary("Get account by puuid.")]
public class GetAccountByPuuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : ShardMethodBase<AccountDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Puuid { get; set; } = string.Empty;
}