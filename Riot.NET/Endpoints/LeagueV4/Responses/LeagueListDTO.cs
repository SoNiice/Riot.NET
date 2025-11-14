using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.LeagueV4.Responses;

public struct LeagueListDTO
{
    [JsonProperty("leagueId")] public string LeagueId { get; set; }
    [JsonProperty("entries")] public List<LeagueEntryDTO> Entries { get; set; }
    [JsonProperty("tier")] public Tier Tier { get; set; }
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("queue")]
    [JsonConverter(typeof(QueueConverterFromString))]
    public Queue Queue { get; set; }
}