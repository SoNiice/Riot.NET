using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct InfoTimeLineDTO
{
    [JsonProperty("endOfGameResult")] public string EndOfGameResult { get; set; }
    [JsonProperty("frameInterval")] public long FrameInterval { get; set; }
    [JsonProperty("gameId")] public long GameId { get; set; }
    [JsonProperty("participants")] public List<ParticipantTimeLineDTO> Participants { get; set; }
    [JsonProperty("frames")] public List<FramesTimeLineDTO> Frames { get; set; }
}