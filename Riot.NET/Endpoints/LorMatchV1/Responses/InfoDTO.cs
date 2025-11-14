using Newtonsoft.Json;
using Riot.NET.Converters;
using Riot.NET.Enums;

namespace Riot.NET.Endpoints.LorMatchV1.Responses;

public struct InfoDTO
{
    [JsonProperty("game_mode")] public LoRGameMode GameMode { get; set; }
    [JsonProperty("game_type")] public LoRGameType? GameType { get; set; }

    [JsonProperty("game_start_time_utc")]
    [JsonConverter(typeof(DateTimeConverterFromString))]
    public DateTime GameStartTime { get; set; }

    [JsonProperty("game_version")] public string GameVersion { get; set; }
    [JsonProperty("game_format")] public LoRGameFormat GameFormat { get; set; }
    [JsonProperty("players")] public List<PlayerDTO> Players { get; set; }
    [JsonProperty("total_turn_count")] public int TotalTurnCount { get; set; }
}