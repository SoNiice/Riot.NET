using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct BlockDTO
{
    [JsonProperty("items")] public List<BlockItemDTO> Items { get; set; }
    [JsonProperty("recMath")] public bool RecMath { get; set; }
    [JsonProperty("type")] public string Type { get; set; }
}