using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Map.Responses;

public struct MapListDTO
{
    [JsonProperty("type")] public string Type { get; set; }
    [JsonProperty("version")] public string Version { get; set; }
    [JsonProperty("data")] public Dictionary<int, MapDTO> Data { get; set; }
}