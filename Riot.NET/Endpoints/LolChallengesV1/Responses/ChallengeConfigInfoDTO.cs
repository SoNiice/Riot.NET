using Newtonsoft.Json;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.LolChallengesV1.Responses;

public struct ChallengeConfigInfoDTO
{
    [JsonProperty("id")] public long Id { get; set; }
    [JsonProperty("localizedNames")] public Dictionary<string, Localization> LocalizedNames { get; set; }
    [JsonProperty("state")] public State State { get; set; }
    [JsonProperty("tracking")] public Tracking Tracking { get; set; }
    [JsonProperty("startTimestamp")] public long StartTimestamp { get; set; }
    [JsonProperty("endTimestamp")] public long EndTimestamp { get; set; }
    [JsonProperty("leaderboard")] public bool Leaderboard { get; set; }
    [JsonProperty("thresholds")] public Dictionary<ChallengeLevel, double> Thresholds { get; set; }
}