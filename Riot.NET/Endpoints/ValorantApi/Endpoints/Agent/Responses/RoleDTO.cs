using Newtonsoft.Json;

namespace Riot.NET.Endpoints.ValorantApi.Endpoints.Agent.Responses;

public struct RoleDTO
{
    [JsonProperty("uuid")] public Guid Uuid { get; set; }
    [JsonProperty("displayName")] public string DisplayName { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("displayIcon")] public Uri DisplayIcon { get; set; }
    [JsonProperty("assetPath")] public string AssetPath { get; set; }
}