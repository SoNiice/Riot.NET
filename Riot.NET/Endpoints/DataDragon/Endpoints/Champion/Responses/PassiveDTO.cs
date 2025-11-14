using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct PassiveDTO
{
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("image")] public ImageDTO Image { get; set; }
}