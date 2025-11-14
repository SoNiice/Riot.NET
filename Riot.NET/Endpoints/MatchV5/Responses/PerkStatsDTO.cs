using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct PerkStatsDTO
{
    [JsonProperty("defense")] public int Defense { get; set; }
    [JsonProperty("flex")] public int Flex { get; set; }
    [JsonProperty("offense")] public int Offense { get; set; }
}