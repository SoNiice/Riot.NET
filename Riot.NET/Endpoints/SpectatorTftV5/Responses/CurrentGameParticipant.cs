using Newtonsoft.Json;

namespace Riot.NET.Endpoints.SpectatorTftV5.Responses;

public struct CurrentGameParticipant
{
    [JsonProperty("championId")] public long ChampionId { get; set; }
    [JsonProperty("profileIconId")] public long ProfileIconId { get; set; }
    [JsonProperty("teamId")] public long TeamId { get; set; }
    [JsonProperty("summonerId")] public string SummonerId { get; set; }
    [JsonProperty("puuid")] public string Puuid { get; set; }
    [JsonProperty("spell1Id")] public long Spell1Id { get; set; }
    [JsonProperty("spell2Id")] public long Spell2Id { get; set; }

    [JsonProperty("gameCustomizationObjects")]
    public List<GameCustomizationObject> GameCustomizationObjects { get; set; }
}