using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item.Responses;

public struct ItemModifierDTO
{
    [JsonProperty("image")] public ImageDTO Image { get; set; }
}