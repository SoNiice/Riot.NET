using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.AccountV1.Responses;

public struct ActiveShardDTO
{
    [JsonProperty("puuid")] public string Puuid { get; set; }

    [JsonProperty("game")]
    [JsonConverter(typeof(ShardGameConverterFromString))]
    public ShardGame Game { get; set; }

    [JsonProperty("activeShard")]
    [JsonConverter(typeof(ShardConverterFromString))]
    public Shard ActiveShard { get; set; }
}