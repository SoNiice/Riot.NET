using Newtonsoft.Json;

namespace Riot.NET.Endpoints.LorMatchV1.Responses;

public struct PlayerDTO
{
    [JsonProperty("puuid")] public string Puuid { get; set; }
    [JsonProperty("deck_id")] public string DeckId { get; set; }
    [JsonProperty("deck_code")] public string DeckCode { get; set; }
    [JsonProperty("factions")] public List<string> Factions { get; set; }
    [JsonProperty("game_outcome")] public string GameOutcome { get; set; }
    [JsonProperty("order_of_play")] public int OrderOfPlay { get; set; }
}