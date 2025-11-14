using Newtonsoft.Json;

namespace Riot.NET.Endpoints.LolChallengesV1.Responses;

public struct Localization
{
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("shortDescription")] public string ShortDescription { get; set; }
}