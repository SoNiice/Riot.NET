using Newtonsoft.Json;

namespace Riot.NET.Endpoints.LorMatchV1.Responses;

public struct MetadataDTO
{
    [JsonProperty("data_version")] public string DataVersion { get; set; }
    [JsonProperty("match_id")] public string MatchId { get; set; }
    [JsonProperty("participants")] public List<string> Participants { get; set; }
}