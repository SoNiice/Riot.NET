namespace Riot.NET.Attributes;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class EndpointAttribute(string uri) : Attribute
{
    public string Uri { get; set; } = uri;
}