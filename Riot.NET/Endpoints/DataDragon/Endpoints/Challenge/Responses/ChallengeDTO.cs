using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Responses;

public struct ChallengeDTO
{
    [JsonProperty("id")] public int Id { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("shortDescription")] public string ShortDescription { get; set; }
    [JsonProperty("hasLeaderboard")] public bool HasLeaderboard { get; set; }
    [JsonProperty("levelToIconPath")] public LevelToIconPathDTO LevelToIconPath { get; set; }
    [JsonProperty("thresholds")] public ThresholdsDTO Thresholds { get; set; }
}