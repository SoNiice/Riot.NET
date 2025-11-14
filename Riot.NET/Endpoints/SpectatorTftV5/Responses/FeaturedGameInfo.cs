using Newtonsoft.Json;

namespace Riot.NET.Endpoints.SpectatorTftV5.Responses;

public struct FeaturedGameInfo
{
    [JsonProperty("gameMode")] public string GameMode { get; set; }
    [JsonProperty("gameLength")] public long GameLength { get; set; }
    [JsonProperty("mapId")] public long MapId { get; set; }
    [JsonProperty("gameType")] public string GameType { get; set; }
    [JsonProperty("bannedChampions")] public List<BannedChampion> BannedChampions { get; set; }
    [JsonProperty("gameId")] public long GameId { get; set; }
    [JsonProperty("observers")] public Observer Observers { get; set; }
    [JsonProperty("gameQueueConfigId")] public long GameQueueConfigId { get; set; }
    [JsonProperty("participants")] public List<Participant> Participants { get; set; }
    [JsonProperty("platformId")] public string PlatformId { get; set; }
}