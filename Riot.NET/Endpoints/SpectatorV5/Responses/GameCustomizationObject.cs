using Newtonsoft.Json;

namespace Riot.NET.Endpoints.SpectatorV5.Responses;

public struct GameCustomizationObject
{
    [JsonProperty("category")] public string Category { get; set; }
    [JsonProperty("content")] public string Content { get; set; }
}