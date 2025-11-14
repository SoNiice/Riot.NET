using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.AccountV1.Responses;

public struct AccountRegionDTO
{
    [JsonProperty("puuid")] public string Puuid { get; set; }

    [JsonProperty("game")]
    [JsonConverter(typeof(RegionGameConverterFromString))]
    public RegionGame Game { get; set; }

    [JsonProperty("region")]
    [JsonConverter(typeof(RegionConverterFromString))]
    public Region Region { get; set; }
}