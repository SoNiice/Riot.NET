using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct TimeLineDTO
{
    [JsonProperty("metadata")] public MetadataTimeLineDTO Metadata { get; set; }
    [JsonProperty("info")] public InfoTimeLineDTO Info { get; set; }
}