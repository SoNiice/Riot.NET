using Newtonsoft.Json;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct ChampionDTO
{
    [JsonProperty("allytips")] public List<string> AllyTips { get; set; }
    [JsonProperty("blurb")] public string Blurb { get; set; }
    [JsonProperty("enemytips")] public List<string> EnemyTips { get; set; }
    [JsonProperty("key")] public int Key { get; set; }
    [JsonProperty("image")] public ImageDTO Image { get; set; }
    [JsonProperty("info")] public InfoDTO Info { get; set; }
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("lore")] public string Lore { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("partype")] public string Partype { get; set; }
    [JsonProperty("passive")] public PassiveDTO Passive { get; set; }
    [JsonProperty("recommended")] public List<RecommendedDTO> RecommendedItems { get; set; }
    [JsonProperty("skins")] public List<SkinDTO> Skins { get; set; }
    [JsonProperty("spells")] public List<SpellDTO> Spells { get; set; }
    [JsonProperty("stats")] public StatsDTO Stats { get; set; }
    [JsonProperty("tags")] public List<ChampionTag> Tags { get; set; }
    [JsonProperty("title")] public string Title { get; set; }
}