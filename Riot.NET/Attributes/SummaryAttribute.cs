namespace Riot.NET.Attributes;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class SummaryAttribute(string summary, string? returns = null) : Attribute
{
    public string Summary { get; set; } = summary;
    public string? Returns { get; set; } = returns;
}