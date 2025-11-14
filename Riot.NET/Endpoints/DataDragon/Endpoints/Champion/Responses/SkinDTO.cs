using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct SkinDTO
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("num")] public int Num { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("chromas")] public bool Chromas { get; set; }
}