using Newtonsoft.Json;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.LolChallengesV1.Responses;

public struct ChallengePoints
{
    [JsonProperty("level")] public ChallengeLevel Level { get; set; }
    [JsonProperty("current")] public long Current { get; set; }
    [JsonProperty("max")] public long Max { get; set; }
    [JsonProperty("percentile")] public double Percentile { get; set; }
}