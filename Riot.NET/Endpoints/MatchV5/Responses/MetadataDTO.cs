using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct MetadataDTO
{
    [JsonProperty("dataVersion")] public string DataVersion { get; set; }
    [JsonProperty("matchId")] public string MatchId { get; set; }
    [JsonProperty("participants")] public List<string> Participants { get; set; }
}