using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct SpellDTO
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("tooltip")] public string Tooltip { get; set; }
    [JsonProperty("levelTip")] public LevelTipDTO LevelTip { get; set; }
    [JsonProperty("maxRank")] public int MaxRank { get; set; }
    [JsonProperty("cooldown")] public List<double> Cooldowns { get; set; }
    [JsonProperty("cooldownBurn")] public string CooldownBurn { get; set; }
    [JsonProperty("cost")] public List<int> Costs { get; set; }
    [JsonProperty("costBurn")] public string CostBurn { get; set; }
    [JsonProperty("effect")] public List<List<double>> Effects { get; set; }
    [JsonProperty("effectBurn")] public List<string> EffectBurns { get; set; }
    [JsonProperty("vars")] public List<VarsDTO> Vars { get; set; }
    [JsonProperty("costType")] public string CostType { get; set; }
    [JsonProperty("maxammo")] public string MaxAmmo { get; set; }
    [JsonProperty("range")] public List<long> Range { get; set; }
    [JsonProperty("rangeBurn")] public string RangeBurn { get; set; }
    [JsonProperty("image")] public ImageDTO Image { get; set; }
    [JsonProperty("resource")] public string Resource { get; set; }
}