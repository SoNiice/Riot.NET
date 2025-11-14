using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct RecommendedDTO
{
    [JsonProperty("blocks")] public List<BlockDTO> Blocks { get; set; }
    [JsonProperty("champion")] public string Champion { get; set; }
    [JsonProperty("map")] public string Map { get; set; }
    [JsonProperty("mode")] public string Mode { get; set; }
    [JsonProperty("priority")] public bool Priority { get; set; }
    [JsonProperty("title")] public string Title { get; set; }
    [JsonProperty("type")] public string Type { get; set; }
}