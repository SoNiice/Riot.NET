using Riot.NET.Attributes;

namespace Riot.NET.Enums;

/// <summary>
/// Games using the <see cref="Region"/> system.
/// <list type="bullet">
/// <item><term><see cref="RegionGame.LeagueOfLegends"/></term></item>
/// <item><term><see cref="RegionGame.TeamfightTactics"/></term></item>
/// </list>
/// </summary>
public enum RegionGame
{
    /// <summary>
    /// League of Legends
    /// </summary>
    [Game("LoL")] LeagueOfLegends,

    /// <summary>
    /// Teamfight Tactics
    /// </summary>
    [Game("TFT")] TeamfightTactics
}