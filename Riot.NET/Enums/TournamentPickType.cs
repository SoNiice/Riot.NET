using Newtonsoft.Json;
using Riot.NET.Converters;

namespace Riot.NET.Enums;

/// <summary>
///     Pick type of the game (Tournament API).
/// <list type="bullet">
/// <item><term><see cref="TournamentPickType.BlindPick"/></term></item>
/// <item><term><see cref="TournamentPickType.DraftMode"/></term></item>
/// <item><term><see cref="TournamentPickType.AllRandom"/></term></item>
/// <item><term><see cref="TournamentPickType.TournamentDraft"/></term></item>
/// </list>
/// </summary>
[JsonConverter(typeof(TournamentPickTypeConverter))]
public enum TournamentPickType
{
    /// <summary>
    /// Blind pick mode.
    /// </summary>
    BlindPick,

    /// <summary>
    /// Draft pick mode.
    /// </summary>
    DraftMode,

    /// <summary>
    /// All random mode.
    /// </summary>
    AllRandom,

    /// <summary>
    /// Tournament draft mode (adds ability to pause).
    /// </summary>
    TournamentDraft
}