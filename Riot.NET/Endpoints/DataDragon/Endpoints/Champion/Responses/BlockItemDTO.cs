using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct BlockItemDTO
{
    [JsonProperty("count")] public int Count { get; set; }
    [JsonProperty("id")] public string Id { get; set; }
}