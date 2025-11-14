using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.TournamentStubV5.Responses;

public struct LobbyEventV5DTO
{
    [JsonProperty("timestamp")]
    [JsonConverter(typeof(DateTimeConverterFromStringTimestampLong))]
    public DateTime Timestamp { get; set; }

    [JsonProperty("eventType")] public TournamentEventType EventType { get; set; }
    [JsonProperty("puuid")] public long Puuid { get; set; }
}