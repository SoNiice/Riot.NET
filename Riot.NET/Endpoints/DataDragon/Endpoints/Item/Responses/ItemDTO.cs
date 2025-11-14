using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item.Responses;

public struct ItemDTO
{
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("colloq")] public string Colloq { get; set; }
    [JsonProperty("plaintext")] public string Plaintext { get; set; }
    [JsonProperty("into")] public List<int> Into { get; set; }
    [JsonProperty("from")] public List<int> From { get; set; }
    [JsonProperty("image")] public ImageDTO Image { get; set; }
    [JsonProperty("gold")] public GoldDTO Gold { get; set; }
    [JsonProperty("tags")] public List<string> Tags { get; set; }
    [JsonProperty("maps")] public Dictionary<int, bool> Maps { get; set; }
    [JsonProperty("stats")] public Dictionary<string, double> Stats { get; set; }
    [JsonProperty("depth")] public int Depth { get; set; }
    [JsonProperty("inStore")] public bool InStore { get; set; }
    [JsonProperty("effect")] public Dictionary<string, double> Effect { get; set; }
    [JsonProperty("consumed")] public bool Consumed { get; set; }
    [JsonProperty("stacks")] public int Stacks { get; set; }
    [JsonProperty("hideFromAll")] public bool HideFromAll { get; set; }
    [JsonProperty("consumeOnFull")] public bool ConsumeOnFull { get; set; }
    [JsonProperty("specialRecipe")] public long SpecialRecipe { get; set; }
    [JsonProperty("requiredChampion")] public string RequiredChampion { get; set; }
}