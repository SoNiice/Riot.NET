using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct ChampionListDTO
{
    [JsonProperty("type")] public string Type { get; set; }
    [JsonProperty("format")] public string Format { get; set; }
    [JsonProperty("version")] public string Version { get; set; }
    [JsonProperty("data")] public Dictionary<string, ChampionDTO> Data { get; set; }
    [JsonProperty("keys")] public Dictionary<int, string> Keys { get; set; }
}