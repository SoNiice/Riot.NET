using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.LeagueV4.Responses;

public struct LeagueEntryDTO
{
    [JsonProperty("leagueId")] public string LeagueId { get; set; }
    [JsonProperty("summonerId")] public string SummonerId { get; set; }
    [JsonProperty("puuid")] public string Puuid { get; set; }

    [JsonProperty("queueType")]
    [JsonConverter(typeof(QueueConverterFromString))]
    public Queue Queue { get; set; }

    [JsonProperty("tier")] public Tier Tier { get; set; }
    [JsonProperty("rank")] public Division Division { get; set; }
    [JsonProperty("leaguePoints")] public int LeaguePoints { get; set; }
    [JsonProperty("wins")] public int Wins { get; set; }
    [JsonProperty("losses")] public int Losses { get; set; }
    [JsonProperty("hotStreak")] public bool HotStreak { get; set; }
    [JsonProperty("veteran")] public bool Veteran { get; set; }
    [JsonProperty("freshBlood")] public bool FreshBlood { get; set; }
    [JsonProperty("inactive")] public bool Inactive { get; set; }
    [JsonProperty("miniSeries")] public MiniSeriesDTO MiniSeries { get; set; }
}