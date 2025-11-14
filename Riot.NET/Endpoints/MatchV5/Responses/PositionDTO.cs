using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct PositionDTO
{
    [JsonProperty("x")] public int X { get; set; }
    [JsonProperty("y")] public int Y { get; set; }
}