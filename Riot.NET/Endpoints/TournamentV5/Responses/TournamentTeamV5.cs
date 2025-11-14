using Newtonsoft.Json;

namespace Riot.NET.Endpoints.TournamentV5.Responses;

public struct TournamentTeamV5
{
    [JsonProperty("puuid")] public string Puuid { get; set; }
}