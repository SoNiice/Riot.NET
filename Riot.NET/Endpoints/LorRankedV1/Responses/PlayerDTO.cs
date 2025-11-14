using Newtonsoft.Json;

namespace Riot.NET.Endpoints.LorRankedV1.Responses;

public struct PlayerDTO
{
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("rank")] public int Rank { get; set; }
    [JsonProperty("lp")] public double LeaguePoints { get; set; }
}