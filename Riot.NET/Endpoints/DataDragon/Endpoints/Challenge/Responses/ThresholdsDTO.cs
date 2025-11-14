using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Responses;

public struct ThresholdsDTO
{
    [JsonProperty("IRON")] public ThresholdDTO Iron { get; set; }
    [JsonProperty("BRONZE")] public ThresholdDTO Bronze { get; set; }
    [JsonProperty("SILVER")] public ThresholdDTO Silver { get; set; }
    [JsonProperty("GOLD")] public ThresholdDTO Gold { get; set; }
    [JsonProperty("PLATINUM")] public ThresholdDTO Platinum { get; set; }
    [JsonProperty("DIAMOND")] public ThresholdDTO Diamond { get; set; }
    [JsonProperty("MASTER")] public ThresholdDTO Master { get; set; }
    [JsonProperty("GRANDMASTER")] public ThresholdDTO Grandmaster { get; set; }
    [JsonProperty("CHALLENGER")] public ThresholdDTO Challenger { get; set; }
}