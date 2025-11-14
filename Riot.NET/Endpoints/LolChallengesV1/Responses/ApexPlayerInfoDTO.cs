using Newtonsoft.Json;

namespace Riot.NET.Endpoints.LolChallengesV1.Responses;

public struct ApexPlayerInfoDTO
{
    [JsonProperty("position")] public long Position { get; set; }
    [JsonProperty("puuid")] public string Puuid { get; set; }
    [JsonProperty("value")] public long Value { get; set; }
}