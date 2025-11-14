using Newtonsoft.Json;
using Riot.NET.Converters;

namespace Riot.NET.Enums;

/// <summary>
///     Mode of the game (Tournament API).
/// <list type="bullet">
/// <item><term><see cref="TournamentMapType.SummonersRift"/></term></item>
/// <item><term><see cref="TournamentMapType.HowlingAbyss"/></term></item>
/// </list>
/// </summary>
[JsonConverter(typeof(TournamentMapTypeConverter))]
public enum TournamentMapType
{
    /// <summary>
    /// Summoner's Rift map.
    /// </summary>
    SummonersRift,

    /// <summary>
    /// Howling Abyss (ARAM) map.
    /// </summary>
    HowlingAbyss
}