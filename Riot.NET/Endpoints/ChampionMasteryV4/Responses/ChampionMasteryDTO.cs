using Newtonsoft.Json;
using Riot.NET.Converters;

namespace Riot.NET.Endpoints.ChampionMasteryV4.Responses;

public struct ChampionMasteryDTO
{
    [JsonProperty("puuid")] public string Puuid { get; set; }

    [JsonProperty("championPointsUntilNextLevel")]
    public long ChampionPointsUntilNextLevel { get; set; }

    [JsonProperty("championId")] public long ChampionId { get; set; }

    [JsonProperty("lastPlayTime")]
    [JsonConverter(typeof(DateTimeConverterFromLong))]
    public DateTime LastPlayTime { get; set; }

    [JsonProperty("championLevel")] public int ChampionLevel { get; set; }
    [JsonProperty("championPoints")] public int ChampionPoints { get; set; }


    [JsonProperty("championPointsSinceLastLevel")]
    public long ChampionPointsSinceLastLevel { get; set; }

    [JsonProperty("markRequiredForNextLevel")]
    public int MarkRequiredForNextLevel { get; set; }

    [JsonProperty("championSeasonMilestone")]
    public int ChampionSeasonMilestone { get; set; }

    [JsonProperty("nextSeasonMilestone")] public NextSeasonMilestonesDTO NextSeasonMilestone { get; set; }
    [JsonProperty("tokensEarned")] public int TokensEarned { get; set; }
    [JsonProperty("milestoneGrades")] public List<string> MilestoneGrades { get; set; }
}