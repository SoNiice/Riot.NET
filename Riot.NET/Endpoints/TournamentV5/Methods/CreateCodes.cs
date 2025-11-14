using System.ComponentModel;
using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.TournamentV5.Methods;

[Path("/codes?tournamentId={0}&count={1}", "POST")]
[RateLimit(TimeUnit.Seconds, 10, 20000)]
[RateLimit(TimeUnit.Minutes, 10, 1200000)]
public class CreateCodes(string endpoint, RateLimiter.RateLimiter rateLimiter) : StaticShardMethodBase<List<string>>(Shard.Americas, endpoint, rateLimiter)
{
    [RequestParameter(0)] public long TournamentId { get; set; }

    [RequestParameter(1)]
    [DefaultValue(1)]
    public int Count { get; set; }

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
    [DefaultValue(true)]
    public bool EnoughPlayers { get; set; }

    [BodyParameter(4)] [DefaultValue(0)] public int TeamSize { get; set; }

    [BodyParameter(5)] [DefaultValue("")] public string MetaData { get; set; } = string.Empty;

    [BodyParameter(6)]
    [DefaultValue(null)]
    public HashSet<string> AllowedParticipants { get; set; } = [];
}