using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct MissionsDTO
{
    [JsonProperty("playerScore0")] public int PlayerScore0 { get; set; }
    [JsonProperty("playerScore1")] public int PlayerScore1 { get; set; }
    [JsonProperty("playerScore2")] public int PlayerScore2 { get; set; }
    [JsonProperty("playerScore3")] public int PlayerScore3 { get; set; }
    [JsonProperty("playerScore4")] public int PlayerScore4 { get; set; }
    [JsonProperty("playerScore5")] public int PlayerScore5 { get; set; }
    [JsonProperty("playerScore6")] public int PlayerScore6 { get; set; }
    [JsonProperty("playerScore7")] public int PlayerScore7 { get; set; }
    [JsonProperty("playerScore8")] public int PlayerScore8 { get; set; }
    [JsonProperty("playerScore9")] public int PlayerScore9 { get; set; }
    [JsonProperty("playerScore10")] public int PlayerScore10 { get; set; }
    [JsonProperty("playerScore11")] public int PlayerScore11 { get; set; }
}