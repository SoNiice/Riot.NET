using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.TournamentV5.Responses;

public struct TournamentGamesV5
{
    [JsonProperty("startTime")]
    [JsonConverter(typeof(DateTimeConverterFromLong))]
    public DateTime StartTime { get; set; }

    [JsonProperty("winningTeam")] public List<TournamentTeamV5> WinningTeam { get; set; }
    [JsonProperty("losingTeam")] public List<TournamentTeamV5> LosingTeam { get; set; }
    [JsonProperty("shortCode")] public string ShortCode { get; set; }
    [JsonProperty("metaData")] public string MetaData { get; set; }
    [JsonProperty("gameId")] public long GameId { get; set; }
    [JsonProperty("gameName")] public string GameName { get; set; }
    [JsonProperty("gameType")] public string GameType { get; set; }
    [JsonProperty("gameMap")] public string GameMap { get; set; }
    [JsonProperty("gameMode")] public string GameMode { get; set; }

    [JsonProperty("region")]
    [JsonConverter(typeof(RegionConverterFromString))]
    public Region Region { get; set; }
}