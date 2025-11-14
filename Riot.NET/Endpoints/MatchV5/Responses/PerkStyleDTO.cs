using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct PerkStyleDTO
{
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("selections")] public List<PerkStyleSelectionDTO> Selections { get; set; }
    [JsonProperty("style")] public int Style { get; set; }
}