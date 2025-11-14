using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item.Responses;

public struct GoldDTO
{
    [JsonProperty("base")] public long Base { get; set; }
    [JsonProperty("total")] public long Total { get; set; }
    [JsonProperty("sell")] public long Sell { get; set; }
    [JsonProperty("purchasable")] public bool Purchasable { get; set; }
}