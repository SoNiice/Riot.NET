using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct InfoDTO
{
    [JsonProperty("attack")] public int Attack { get; set; }
    [JsonProperty("defense")] public int Defense { get; set; }
    [JsonProperty("magic")] public int Magic { get; set; }
    [JsonProperty("difficulty")] public int Difficulty { get; set; }
}