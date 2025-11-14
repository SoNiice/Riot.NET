using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct LevelTipDTO
{
    [JsonProperty("effect")] public List<string> Effects { get; set; }
    [JsonProperty("label")] public List<string> Labels { get; set; }
}