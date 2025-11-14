namespace Riot.NET.Attributes;

[AttributeUsage(AttributeTargets.Field)]
internal sealed class GameAttribute(string game) : Attribute
{
    public string Game { get; set; } = game;
}