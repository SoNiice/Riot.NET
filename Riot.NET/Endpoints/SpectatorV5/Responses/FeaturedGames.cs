using Newtonsoft.Json;

namespace Riot.NET.Endpoints.SpectatorV5.Responses;

public struct FeaturedGames
{
    [JsonProperty("gameList")] public List<FeaturedGameInfo> GameList { get; set; }

    [JsonProperty("clientRefreshInterval")]
    public long ClientRefreshInterval { get; set; }
}