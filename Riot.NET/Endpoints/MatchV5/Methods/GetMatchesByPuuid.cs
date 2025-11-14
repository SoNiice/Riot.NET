using System.ComponentModel;
using Riot.NET.Attributes;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.MatchV5.Methods;

[Path("/matches/by-puuid/{0}/ids?startTime={1}&endTime={2}&queue={3}&type={4}&start={5}&count={6}")]
public class GetMatchesByPuuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : ShardMethodBase<List<string>>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public string Puuid { get; set; } = string.Empty;

    [RequestParameter(1)]
    [DefaultValue(null)]
    public DateTime? StartTime { get; set; }

    [RequestParameter(2)]
    [DefaultValue(null)]
    public DateTime? EndTime { get; set; }

    [RequestParameter(3)]
    [DefaultValue(null)]
    public int? Queue { get; set; }

    [RequestParameter(4)]
    [DefaultValue(null)]
    public Riot.NET.Enums.MatchType? Type { get; set; }

    [RequestParameter(5)]
    [DefaultValue(null)]
    public int? Start { get; set; }

    [RequestParameter(6)]
    [DefaultValue(20)]
    public int? Count { get; set; }
}