using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.LolStatusV4.Responses;

public struct UpdateDTO
{
    [JsonProperty("id")] public int Id { get; set; }
    [JsonProperty("author")] public string Author { get; set; }
    [JsonProperty("publish")] public bool Publish { get; set; }
    [JsonProperty("publish_locations")] public List<PublishLocation> PublishLocations { get; set; }
    [JsonProperty("translations")] public List<ContentDTO> Translations { get; set; }

    [JsonProperty("created_at")]
    [JsonConverter(typeof(DateTimeConverterFromString))]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    [JsonConverter(typeof(DateTimeConverterFromString))]
    public DateTime UpdatedAt { get; set; }
}