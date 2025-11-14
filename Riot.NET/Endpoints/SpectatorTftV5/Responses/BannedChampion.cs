using Newtonsoft.Json;

namespace Riot.NET.Endpoints.SpectatorTftV5.Responses;

public struct BannedChampion
{
    [JsonProperty("pickTurn")] public int PickTurn { get; set; }
    [JsonProperty("championId")] public long ChampionId { get; set; }
    [JsonProperty("teamId")] public long TeamId { get; set; }
}