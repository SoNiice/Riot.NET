using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct ParticipantTimeLineDTO
{
    [JsonProperty("participantId")] public int ParticipantId { get; set; }
    [JsonProperty("puuid")] public string Puuid { get; set; }
}