using Newtonsoft.Json;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;

public struct StatsDTO
{
    [JsonProperty("hp")] public double Hp;
    [JsonProperty("hpperlevel")] public double HpPerLevel;
    [JsonProperty("mp")] public double Mp;
    [JsonProperty("mpperlevel")] public double MpPerLevel;
    [JsonProperty("movespeed")] public double Movespeed;
    [JsonProperty("armor")] public double Armor;
    [JsonProperty("armorperlevel")] public double ArmorPerLevel;
    [JsonProperty("spellblock")] public double Spellblock;
    [JsonProperty("spellblockperlevel")] public double SpellblockPerLevel;
    [JsonProperty("attackrange")] public double Attackrange;
    [JsonProperty("hpregen")] public double HpRegen;
    [JsonProperty("hpregenperlevel")] public double HpRegenPerLevel;
    [JsonProperty("mpregen")] public double MpRegen;
    [JsonProperty("mpregenperlevel")] public double MpRegenPerLevel;
    [JsonProperty("crit")] public double Crit;
    [JsonProperty("critperlevel")] public double CritPerLevel;
    [JsonProperty("attackdamage")] public double Attackdamage;
    [JsonProperty("attackdamageperlevel")] public double AttackdamagePerLevel;
    [JsonProperty("attackspeedperlevel")] public double AttackspeedPerLevel;
    [JsonProperty("attackspeed")] public double Attackspeed;
}