namespace Riot.NET.Attributes;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class PathAttribute(string uri, string method = "GET") : Attribute
{
    public string Uri { get; set; } = uri;
    public string Method { get; set; } = method;
}