using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.TournamentStubV5.Responses;

public struct TournamentCodeV5DTO
{
    [JsonProperty("code")] public string Code { get; set; }
    [JsonProperty("lobbyName")] public string LobbyName { get; set; }
    [JsonProperty("metaData")] public string MetaData { get; set; }
    [JsonProperty("password")] public string Password { get; set; }
    [JsonProperty("teamSize")] public int TeamSize { get; set; }
    [JsonProperty("providerId")] public int ProviderId { get; set; }
    [JsonProperty("pickType")] public TournamentPickType PickType { get; set; }
    [JsonProperty("tournamentId")] public int TournamentId { get; set; }
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("region")]
    [JsonConverter(typeof(RegionConverterFromString))]
    public Region Region { get; set; }

    [JsonProperty("map")] public TournamentMapType Map { get; set; }
    [JsonProperty("participants")] public HashSet<string> Participants { get; set; }
}