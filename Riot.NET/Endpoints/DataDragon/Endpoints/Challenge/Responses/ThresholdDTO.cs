using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Responses;

public struct ThresholdDTO
{
    [JsonProperty("value")] public long Value { get; set; }
    [JsonProperty("rewards")] public List<RewardDTO> Rewards { get; set; }
}