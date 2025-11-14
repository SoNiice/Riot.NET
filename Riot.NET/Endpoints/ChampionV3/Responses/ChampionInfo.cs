using Newtonsoft.Json;

namespace Riot.NET.Endpoints.ChampionV3.Responses;

public struct ChampionInfo
{
    [JsonProperty("freeChampionIds")] public List<int> FreeChampionIds { get; set; }

    [JsonProperty("freeChampionIdsForNewPlayers")]
    public List<int> FreeChampionIdsForNewPlayers { get; set; }

    [JsonProperty("maxNewPlayerLevel")] public int MaxNewPlayerLevel { get; set; }
}