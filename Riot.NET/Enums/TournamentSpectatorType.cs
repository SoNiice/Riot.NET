using Newtonsoft.Json;
using Riot.NET.Converters;

namespace Riot.NET.Enums;

/// <summary>
///     Spectator type of the game (Tournament API).
/// <list type="bullet">
/// <item><term><see cref="TournamentSpectatorType.None"/></term></item>
/// <item><term><see cref="TournamentSpectatorType.LobbyOnly"/></term></item>
/// <item><term><see cref="TournamentSpectatorType.All"/></term></item>
/// </list>
/// </summary>
[JsonConverter(typeof(TournamentSpectatorTypeConverter))]
public enum TournamentSpectatorType
{
    /// <summary>
    /// None
    /// </summary>
    None,

    /// <summary>
    /// Lobby only
    /// </summary>
    LobbyOnly,

    /// <summary>
    /// All
    /// </summary>
    All
}