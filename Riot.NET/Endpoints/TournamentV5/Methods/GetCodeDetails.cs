using System.ComponentModel;
using Riot.NET.Attributes;
using Riot.NET.Endpoints.TournamentV5.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.TournamentV5.Methods;

[Path("/codes/{0}")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class GetCodeDetails(string endpoint, RateLimiter.RateLimiter rateLimiter) : StaticShardMethodBase<TournamentCodeV5DTO>(Shard.Americas, endpoint, rateLimiter)
{
    [RequestParameter(0)] public string TournamentCode { get; set; } = string.Empty;
}