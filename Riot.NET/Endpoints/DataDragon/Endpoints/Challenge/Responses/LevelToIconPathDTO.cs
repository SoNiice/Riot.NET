using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Responses;

public struct LevelToIconPathDTO
{
    [JsonProperty("IRON")] public string Iron { get; set; }
    [JsonProperty("BRONZE")] public string Bronze { get; set; }
    [JsonProperty("SILVER")] public string Silver { get; set; }
    [JsonProperty("GOLD")] public string Gold { get; set; }
    [JsonProperty("PLATINUM")] public string Platinum { get; set; }
    [JsonProperty("DIAMOND")] public string Diamond { get; set; }
    [JsonProperty("MASTER")] public string Master { get; set; }
    [JsonProperty("GRANDMASTER")] public string Grandmaster { get; set; }
    [JsonProperty("CHALLENGER")] public string Challenger { get; set; }
    [JsonProperty("NONE")] public string None { get; set; }
}