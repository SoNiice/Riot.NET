using Newtonsoft.Json;
using Riot.NET.Converters;

namespace Riot.NET.Endpoints.ClashV1.Responses;

public struct TournamentPhaseDTO
{
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("registrationTime")]
    [JsonConverter(typeof(DateTimeConverterFromLong))]
    public DateTime RegistrationTime { get; set; }

    [JsonProperty("startTime")]
    [JsonConverter(typeof(DateTimeConverterFromLong))]
    public DateTime StartTime { get; set; }

    [JsonProperty("cancelled")] public bool Cancelled { get; set; }
}