using Newtonsoft.Json;

namespace Riot.NET.Endpoints.SpectatorTftV5.Responses;

public struct Perks
{
    [JsonProperty("perkIds")] public List<long> PerkIds { get; set; }
    [JsonProperty("perkStyle")] public long PerkStyle { get; set; }
    [JsonProperty("perkSubStyle")] public long PerkSubStyle { get; set; }
}