using Newtonsoft.Json;

namespace Riot.NET.Endpoints.ClashV1.Responses;

public struct TeamDTO
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("tournamentId")] public int TournamentId { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("iconId")] public int IconId { get; set; }
    [JsonProperty("tier")] public int Tier { get; set; }

    /// <summary>
    /// Summoner ID of the team captain.
    /// </summary>
    [JsonProperty("captain")]
    public string CaptainId { get; set; }

    [JsonProperty("abbreviation")] public string Abbreviation { get; set; }
    [JsonProperty("players")] public List<PlayerDTO> Players { get; set; }
}