using Newtonsoft.Json;
using Riot.NET.Converters;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct InfoDTO
{
    [JsonProperty("endOfGameResult")] public string EndOfGameResult { get; set; }

    [JsonProperty("gameCreation")]
    [JsonConverter(typeof(DateTimeConverterFromLong))]
    public DateTime GameCreation { get; set; }

    [JsonProperty("gameDuration")] public long GameDuration { get; set; }

    [JsonProperty("gameEndTimestamp")]
    [JsonConverter(typeof(DateTimeConverterFromLong))]
    public DateTime GameEnd { get; set; }

    [JsonProperty("gameId")] public long GameId { get; set; }
    [JsonProperty("gameMode")] public string GameMode { get; set; }
    [JsonProperty("gameName")] public string GameName { get; set; }

    [JsonProperty("gameStartTimestamp")]
    [JsonConverter(typeof(DateTimeConverterFromLong))]
    public DateTime GameStart { get; set; }

    [JsonProperty("gameVersion")] public string GameVersion { get; set; }
    [JsonProperty("mapId")] public int MapId { get; set; }
    [JsonProperty("participants")] public List<ParticipantDTO> Participants { get; set; }
    [JsonProperty("platformId")] public string PlatformId { get; set; }
    [JsonProperty("queueId")] public int QueueId { get; set; }
    [JsonProperty("teams")] public List<TeamDTO> Teams { get; set; }
    [JsonProperty("tournamentCode")] public string TournamentCode { get; set; }
}