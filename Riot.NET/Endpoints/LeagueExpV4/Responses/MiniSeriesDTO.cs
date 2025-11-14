using Newtonsoft.Json;

namespace Riot.NET.Endpoints.LeagueExpV4.Responses;

public struct MiniSeriesDTO
{
    [JsonProperty("losses")] public int Losses { get; set; }
    [JsonProperty("progress")] public string Progress { get; set; }
    [JsonProperty("target")] public int Target { get; set; }
    [JsonProperty("wins")] public int Wins { get; set; }
}