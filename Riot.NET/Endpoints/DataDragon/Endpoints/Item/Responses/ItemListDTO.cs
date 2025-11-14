using Newtonsoft.Json;
using Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Responses;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item.Responses;

public struct ItemListDTO
{
    [JsonProperty("type")] public string Type { get; set; }
    [JsonProperty("version")] public string Version { get; set; }
    [JsonProperty("data")] public Dictionary<int, ItemDTO> Data { get; set; }
}