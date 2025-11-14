using Newtonsoft.Json;

namespace Riot.NET.Endpoints.ClashV1.Responses;

public struct TournamentDTO
{
    [JsonProperty("id")] public int Id { get; set; }
    [JsonProperty("themeId")] public int ThemeId { get; set; }
    [JsonProperty("nameKey")] public string NameKey { get; set; }
    [JsonProperty("nameKeySecondary")] public string NameKeySecondary { get; set; }
    [JsonProperty("schedule")] public List<TournamentPhaseDTO> Schedule { get; set; }
}