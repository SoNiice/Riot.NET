using Newtonsoft.Json;
using Riot.NET.Converters;

namespace Riot.NET.Endpoints.SummonerV4.Responses;

public struct SummonerDTO
{
    [JsonProperty("profileIconId")] public int ProfileIconId { get; set; }

    [JsonProperty("revisionDate")]
    [JsonConverter(typeof(DateTimeConverterFromLong))]
    public DateTime RevisionDate { get; set; }

    [JsonProperty("puuid")] public string Puuid { get; set; }
    [JsonProperty("summonerLevel")] public long SummonerLevel { get; set; }
}