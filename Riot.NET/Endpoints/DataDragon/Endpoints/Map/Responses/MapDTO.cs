using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Map.Responses;

public struct MapDTO
{
    [JsonProperty("MapName")] public string MapName { get; set; }
    [JsonProperty("MapId")] public int MapId { get; set; }
    [JsonProperty("image")] public ImageDTO Image { get; set; }
}