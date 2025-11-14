using Newtonsoft.Json;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Responses;

public struct RewardDTO
{
    [JsonProperty("category")] public ChallengeRewardCategory Category { get; set; }
    [JsonProperty("quantity")] public long Quantity { get; set; }
    [JsonProperty("title")] public string Title { get; set; }
}