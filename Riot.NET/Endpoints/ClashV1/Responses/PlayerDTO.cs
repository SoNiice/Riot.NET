using Newtonsoft.Json;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.ClashV1.Responses;

public struct PlayerDTO
{
    [JsonProperty("summonerId")] public string SummonerId { get; set; }
    [JsonProperty("puuid")] public string Puuid { get; set; }
    [JsonProperty("teamId")] public string TeamId { get; set; }
    [JsonProperty("position")] public Position Position { get; set; }
    [JsonProperty("role")] public ClashRole Role { get; set; }
}