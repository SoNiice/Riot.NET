using Newtonsoft.Json;

namespace Riot.NET.Endpoints.LorStatusV1.Responses;

public struct ContentDTO
{
    [JsonProperty("locale")] public string Locale { get; set; }
    [JsonProperty("content")] public string Content { get; set; }
}