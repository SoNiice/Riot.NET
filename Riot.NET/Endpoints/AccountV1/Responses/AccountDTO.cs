using Newtonsoft.Json;

namespace Riot.NET.Endpoints.AccountV1.Responses;

/// <summary>
/// Struct representing an account.
/// </summary>
public struct AccountDTO
{
    [JsonProperty("puuid")] public string Puuid { get; set; }
    [JsonProperty("gameName")] public string GameName { get; set; }
    [JsonProperty("tagLine")] public string TagLine { get; set; }
}