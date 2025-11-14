using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct EventsTimeLineDTO
{
    [JsonProperty("timestamp")] public long Timestamp { get; set; }
    [JsonProperty("realTimestamp")] public long RealTimestamp { get; set; }
    [JsonProperty("type")] public string Type { get; set; }
}