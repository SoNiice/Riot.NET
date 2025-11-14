using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item.Responses;

public struct ImageDTO
{
    [JsonProperty("full")] public string Full { get; set; }
    [JsonProperty("sprite")] public string Sprite { get; set; }
    [JsonProperty("group")] public string Group { get; set; }
    [JsonProperty("x")] public int X { get; set; }
    [JsonProperty("y")] public int Y { get; set; }
    [JsonProperty("w")] public int Width { get; set; }
    [JsonProperty("h")] public int Height { get; set; }
}