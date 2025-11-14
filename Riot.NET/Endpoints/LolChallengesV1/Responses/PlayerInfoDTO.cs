using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.LolChallengesV1.Responses;

public struct PlayerInfoDTO
{
    [JsonProperty("challenges")] public List<ChallengeInfo> Challenges { get; set; }
    [JsonProperty("preferences")] public PlayerClientPreferences Preferences { get; set; }
    [JsonProperty("totalPoints")] public ChallengePoints TotalPoints { get; set; }
    [JsonProperty("categoryPoints")] public Dictionary<ChallengeCategory, ChallengePoints> CategoryPoints { get; set; }
}

public struct ChallengeInfo
{
    [JsonProperty("challengeId")] public long ChallengeId { get; set; }
    [JsonProperty("percentile")] public double Percentile { get; set; }
    [JsonProperty("level")] public ChallengeLevel Level { get; set; }
    [JsonProperty("value")] public long Value { get; set; }

    [JsonProperty("achievedTime")]
    [JsonConverter(typeof(DateTimeConverterFromLong))]
    public DateTime AchievedTime { get; set; }
}