using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct ObjectiveDTO
{
    [JsonProperty("first")] public bool First { get; set; }
    [JsonProperty("kills")] public int Kills { get; set; }
}