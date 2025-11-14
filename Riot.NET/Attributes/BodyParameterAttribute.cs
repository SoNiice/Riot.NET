namespace Riot.NET.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class BodyParameterAttribute(int order, string? description = null) : Attribute
{
    public int Order { get; } = order;
    public string? Description { get; } = description;
}