using Newtonsoft.Json;

namespace Riot.NET.Endpoints.LolStatusV4.Responses;

public struct PlatformDataDTO
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("locales")] public List<string> Locales { get; set; }
    [JsonProperty("maintenances")] public List<StatusDTO> Maintenances { get; set; }
    [JsonProperty("incidents")] public List<StatusDTO> Incidents { get; set; }
}