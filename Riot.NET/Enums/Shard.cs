using Riot.NET.Attributes;

namespace Riot.NET.Enums;

/// <summary>
/// Riot shard enum.
/// </summary>
public enum Shard
{
    [Region("AMERICAS")] Americas,
    [Region("ASIA")] Asia,
    [Region("EUROPE", "EU")] Europe
}