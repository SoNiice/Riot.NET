using Newtonsoft.Json;

namespace Riot.NET.Endpoints.LolChallengesV1.Responses;

public struct PlayerClientPreferences
{
    [JsonProperty("bannerAccent")] public string BannerAccent { get; set; }
    [JsonProperty("title")] public string Title { get; set; }
    [JsonProperty("challengeIds")] public List<long> ChallengeIds { get; set; }
    [JsonProperty("crestBorder")] public string CrestBorder { get; set; }
    [JsonProperty("prestigeCrestBorderLevel")] public long PrestigeCrestBorderLevel { get; set; }
}