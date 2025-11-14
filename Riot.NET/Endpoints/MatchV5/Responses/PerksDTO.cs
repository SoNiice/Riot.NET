using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct PerksDTO
{
    [JsonProperty("statPerks")] public PerkStatsDTO StatPerks { get; set; }
    [JsonProperty("styles")] public List<PerkStyleDTO> Styles { get; set; }
}