using Newtonsoft.Json;
using Riot.NET.Converters;

namespace Riot.NET.Endpoints.SpectatorTftV5.Responses;

public struct CurrentGameInfo
{
    [JsonProperty("gameId")] public long GameId { get; set; }
    [JsonProperty("gameType")] public string GameType { get; set; }

    [JsonProperty("gameStartTime")]
    [JsonConverter(typeof(DateTimeConverterFromLong))]
    public DateTime GameStartTime { get; set; }

    [JsonProperty("mapId")] public long MapId { get; set; }
    [JsonProperty("gameLength")] public long GameLength { get; set; }
    [JsonProperty("platformId")] public string PlatformId { get; set; }
    [JsonProperty("gameMode")] public string GameMode { get; set; }
    [JsonProperty("bannedChampions")] public List<BannedChampion> BannedChampions { get; set; }
    [JsonProperty("gameQueueConfigId")] public long GameQueueConfigId { get; set; }
    [JsonProperty("observers")] public Observer Observers { get; set; }
    [JsonProperty("participants")] public List<CurrentGameParticipant> Participants { get; set; }
}