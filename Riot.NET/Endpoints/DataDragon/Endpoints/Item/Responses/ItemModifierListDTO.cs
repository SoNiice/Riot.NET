using Newtonsoft.Json;
using Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Responses;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item.Responses;

public struct ItemModifierListDTO
{
    [JsonProperty("type")] public string Type { get; set; }
    [JsonProperty("version")] public string Version { get; set; }
    [JsonProperty("data")] public Dictionary<long, ItemModifierDTO> Data { get; set; }
}