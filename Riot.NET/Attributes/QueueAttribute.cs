namespace Riot.NET.Attributes;

[AttributeUsage(AttributeTargets.Field)]
internal sealed class QueueAttribute(string queue) : Attribute
{
    public string Queue { get; set; } = queue;
}