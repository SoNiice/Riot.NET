using Newtonsoft.Json;

namespace Riot.NET.Endpoints.LorRankedV1.Responses;

public struct LeaderboardDTO
{
    [JsonProperty("players")] public List<PlayerDTO> Players { get; set; }
}