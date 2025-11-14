using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct TeamDTO
{
    [JsonProperty("bans")] public List<BanDTO> Bans { get; set; }

    [JsonProperty("objectives")] public ObjectivesDTO Objectives { get; set; }
    [JsonProperty("teamId")] public int TeamId { get; set; }
    [JsonProperty("win")] public bool Win { get; set; }
}