using Newtonsoft.Json;

namespace Riot.NET.Endpoints.TournamentV5.Responses;

public struct LobbyEventV5DTOWrapper
{
    [JsonProperty("eventList")] public List<LobbyEventV5DTO> EventList { get; set; }
}