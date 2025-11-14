using Riot.NET.Attributes;

namespace Riot.NET.Enums;

/// <summary>
/// Games using the <see cref="Shard"/> system.
/// <list type="bullet">
/// <item><term><see cref="ShardGame.Valorant"/></term></item>
/// <item><term><see cref="ShardGame.LegendsOfRuneterra"/></term></item>
/// </list>
/// </summary>
public enum ShardGame
{
    /// <summary>
    /// Valorant
    /// </summary>
    [Game("VAL")] Valorant,
    /// <summary>
    /// Legends of Runeterra
    /// </summary>
    [Game("LoR")] LegendsOfRuneterra
}