using Newtonsoft.Json;

namespace Riot.NET.Endpoints.ValorantApi.Endpoints.Agent.Responses;

public struct RecruitmentDataDTO
{
    [JsonProperty("counterId")] public Guid CounterId { get; set; }
    [JsonProperty("milestoneId")] public Guid MilestoneId { get; set; }
    [JsonProperty("milestoneThreshold")] public long MilestoneThreshold { get; set; }

    [JsonProperty("useLevelVpCostOverride")]
    public bool UseLevelVpCostOverride { get; set; }

    [JsonProperty("levelVpCostOverride")] public long LevelVpCostOverride { get; set; }
    [JsonProperty("startDate")] public DateTimeOffset StartDate { get; set; }
    [JsonProperty("endDate")] public DateTimeOffset EndDate { get; set; }
}