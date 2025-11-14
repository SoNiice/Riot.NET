using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct ParticipantFrameDTO
{
    [JsonProperty("championStats")] public ChampionStatsDTO ChampionStats { get; set; }
    [JsonProperty("currentGold")] public int CurrentGold { get; set; }
    [JsonProperty("damageStats")] public DamageStatsDTO DamageStats { get; set; }
    [JsonProperty("goldPerSecond")] public int GoldPerSecond { get; set; }
    [JsonProperty("jungleMinionsKilled")] public int JungleMinionsKilled { get; set; }
    [JsonProperty("level")] public int Level { get; set; }
    [JsonProperty("minionsKilled")] public int MinionsKilled { get; set; }
    [JsonProperty("participantId")] public int ParticipantId { get; set; }
    [JsonProperty("position")] public PositionDTO Position { get; set; }

    [JsonProperty("timeEnemySpentControlled")]
    public int TimeEnemySpentControlled { get; set; }

    [JsonProperty("totalGold")] public int TotalGold { get; set; }
    [JsonProperty("xp")] public int Xp { get; set; }
}