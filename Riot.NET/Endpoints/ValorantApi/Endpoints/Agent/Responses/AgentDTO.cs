using Newtonsoft.Json;

namespace Riot.NET.Endpoints.ValorantApi.Endpoints.Agent.Responses;

public struct AgentDTO
{
    [JsonProperty("uuid")] public Guid Uuid { get; set; }
    [JsonProperty("displayName")] public string DisplayName { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("developerName")] public string DeveloperName { get; set; }
    [JsonProperty("releaseDate")] public DateTime ReleaseDate { get; set; }
    [JsonProperty("characterTags")] public string[] CharacterTags { get; set; }
    [JsonProperty("displayIcon")] public Uri DisplayIcon { get; set; }
    [JsonProperty("displayIconSmall")] public Uri DisplayIconSmall { get; set; }
    [JsonProperty("bustPortrait")] public Uri BustPortrait { get; set; }
    [JsonProperty("fullPortrait")] public Uri FullPortrait { get; set; }
    [JsonProperty("fullPortraitV2")] public Uri FullPortraitV2 { get; set; }
    [JsonProperty("killfeedPortrait")] public Uri KillfeedPortrait { get; set; }
    [JsonProperty("background")] public Uri Background { get; set; }

    [JsonProperty("backgroundGradientColors")]
    public string[] BackgroundGradientColors { get; set; }

    [JsonProperty("assetPath")] public string AssetPath { get; set; }

    [JsonProperty("isFullPortraitRightFacing")]
    public bool IsFullPortraitRightFacing { get; set; }

    [JsonProperty("isPlayableCharacter")] public bool IsPlayableCharacter { get; set; }
    [JsonProperty("isAvailableForTest")] public bool IsAvailableForTest { get; set; }
    [JsonProperty("isBaseContent")] public bool IsBaseContent { get; set; }
    [JsonProperty("role")] public RoleDTO? Role { get; set; }
    [JsonProperty("recruitmentData")] public RecruitmentDataDTO? RecruitmentData { get; set; }
    [JsonProperty("abilities")] public List<AbilityDTO> Abilities { get; set; }
    [JsonProperty("voiceLine")] public object VoiceLine { get; set; }
}