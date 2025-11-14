using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct MatchDTO
{
    [JsonProperty("metadata")] public MetadataDTO Metadata { get; set; }
    [JsonProperty("info")] public InfoDTO Info { get; set; }
}