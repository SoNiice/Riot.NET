using System.ComponentModel;
using Riot.NET.Attributes;
using Riot.NET.Endpoints.TournamentStubV5.Responses;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.TournamentV5.Methods;

[Path("/codes/{0}", "PUT")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class UpdateCodeDetails(string endpoint, RateLimiter.RateLimiter rateLimiter) : StaticShardMethodBase<bool?>(Shard.Americas, endpoint, rateLimiter)
{
    [RequestParameter(0)] public string TournamentCode { get; set; } = string.Empty;

    [BodyParameter(0)]
    [DefaultValue(TournamentMapType.SummonersRift)]
    public TournamentMapType MapType { get; set; }

    [BodyParameter(1)]
    [DefaultValue(TournamentPickType.TournamentDraft)]
    public TournamentPickType PickType { get; set; }

    [BodyParameter(2)]
    [DefaultValue(TournamentSpectatorType.None)]
    public TournamentSpectatorType SpectatorType { get; set; }

    [BodyParameter(3)]
    [DefaultValue(null)]
    public HashSet<string> AllowedParticipants { get; set; } = [];
}