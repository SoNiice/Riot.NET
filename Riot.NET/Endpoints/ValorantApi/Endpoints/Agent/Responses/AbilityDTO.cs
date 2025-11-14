using Newtonsoft.Json;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.ValorantApi.Endpoints.Agent.Responses;

public struct AbilityDTO
{
    [JsonProperty("slot")] public ValorantAbilitySlot Slot { get; set; }
    [JsonProperty("displayName")] public string DisplayName { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("displayIcon")] public Uri DisplayIcon { get; set; }
}