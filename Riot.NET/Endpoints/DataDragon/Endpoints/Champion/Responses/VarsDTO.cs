using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct VarsDTO
{
    [JsonProperty("coeff")] public object Coeff { get; set; }
    [JsonProperty("dyn")] public string Dyn { get; set; }
    [JsonProperty("key")] public string Key { get; set; }
    [JsonProperty("link")] public string Link { get; set; }
    [JsonProperty("ranksWith")] public string RanksWith { get; set; }
}