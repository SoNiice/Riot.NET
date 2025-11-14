using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct BanDTO
{
    [JsonProperty("championId")] public int ChampionId { get; set; }
    [JsonProperty("pickTurn")] public int PickTurn { get; set; }
}