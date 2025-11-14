using Newtonsoft.Json;

namespace Riot.NET.Endpoints.ChampionMasteryV4.Responses;

public struct RewardConfigDTO
{
    [JsonProperty("rewardValue")] public string RewardValue { get; set; }
    [JsonProperty("rewardType")] public string RewardType { get; set; }
    [JsonProperty("maximumReward")] public int MaximumReward { get; set; }
}