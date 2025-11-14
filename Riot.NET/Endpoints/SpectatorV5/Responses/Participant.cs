using Newtonsoft.Json;

namespace Riot.NET.Endpoints.SpectatorV5.Responses;

public struct Participant
{
    [JsonProperty("spell2Id")] public long Spell2Id { get; set; }
    [JsonProperty("profileIconId")] public long ProfileIconId { get; set; }
    [JsonProperty("summonerId")] public string SummonerId { get; set; }
    [JsonProperty("puuid")] public string Puuid { get; set; }
    [JsonProperty("championId")] public long ChampionId { get; set; }
    [JsonProperty("teamId")] public long TeamId { get; set; }
    [JsonProperty("spell1Id")] public long Spell1Id { get; set; }
}