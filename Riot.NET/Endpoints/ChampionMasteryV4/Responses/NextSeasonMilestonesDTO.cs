using Newtonsoft.Json;

namespace Riot.NET.Endpoints.ChampionMasteryV4.Responses;

public struct NextSeasonMilestonesDTO
{
    [JsonProperty("requireGradeCounts")] public Dictionary<string, int> RequireGradeCounts { get; set; }
    [JsonProperty("rewardMarks")] public int RewardMarks { get; set; }
    [JsonProperty("bonus")] public bool Bonus { get; set; }
    [JsonProperty("rewardConfig")] public RewardConfigDTO RewardConfig { get; set; }
}