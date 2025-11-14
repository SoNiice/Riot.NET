namespace Riot.NET.Attributes;

[AttributeUsage(AttributeTargets.Field)]
internal sealed class RegionAttribute(string region, params string[] alternatives) : Attribute
{
    public string Region { get; set; } = region;
    public List<string> Alternatives { get; set; } = alternatives.ToList();
}