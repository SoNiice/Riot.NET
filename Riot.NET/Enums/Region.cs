using Riot.NET.Attributes;

namespace Riot.NET.Enums;

/// <summary>
/// Riot Region enum.
/// <list type="bullet">
/// <item><term><see cref="Region.BR"/></term></item>
/// <item><term><see cref="Region.EUNE"/></term></item>
/// <item><term><see cref="Region.EUW"/></term></item>
/// <item><term><see cref="Region.JP"/></term></item>
/// <item><term><see cref="Region.KR"/></term></item>
/// <item><term><see cref="Region.LAN"/></term></item>
/// <item><term><see cref="Region.LAS"/></term></item>
/// <item><term><see cref="Region.ME"/></term></item>
/// <item><term><see cref="Region.NA"/></term></item>
/// <item><term><see cref="Region.OCE"/></term></item>
/// <item><term><see cref="Region.RU"/></term></item>
/// <item><term><see cref="Region.SG"/></term></item>
/// <item><term><see cref="Region.TR"/></term></item>
/// <item><term><see cref="Region.TW"/></term></item>
/// <item><term><see cref="Region.VN"/></term></item>
/// <item><term><see cref="Region.Stub"/></term></item>
/// </list>
/// </summary>
public enum Region
{
    /// <summary>
    /// Brazil
    /// </summary>
    [Region("BR1")] BR,

    /// <summary>
    /// Europe Nordic & East 
    /// </summary>
    [Region("EUN1")] EUNE,

    /// <summary>
    /// Europe West 
    /// </summary>
    [Region("EUW1")] EUW,

    /// <summary>
    /// Japan
    /// </summary>
    [Region("JP1")] JP,

    /// <summary>
    /// Republic of Korea 
    /// </summary>
    [Region("KR")] KR,

    /// <summary>
    /// Latin America North 
    /// </summary>
    [Region("LA1")] LAN,

    /// <summary>
    /// Latin America South 
    /// </summary>
    [Region("LA2")] LAS,

    /// <summary>
    /// Middle East 
    /// </summary>
    [Region("ME1")] ME,

    /// <summary>
    /// North America 
    /// </summary>
    [Region("NA1")] NA,

    /// <summary>
    /// Oceania
    /// </summary>
    [Region("OC1")] OCE,

    /// <summary>
    /// Russia
    /// </summary>
    [Region("RU")] RU,

    /// <summary>
    /// Southeast Asia 
    /// </summary>
    [Region("SG2")] SG,

    /// <summary>
    /// Turkey
    /// </summary>
    [Region("TR1")] TR,

    /// <summary>
    /// Taiwan, Hong Kong and Macao 
    /// </summary>
    [Region("TW2")] TW,

    /// <summary>
    /// Vietnam
    /// </summary>
    [Region("VN2")] VN,

    /// <summary>
    /// Stub, only used for debugging and testing
    /// </summary>
    [Region("STUB")] Stub
}