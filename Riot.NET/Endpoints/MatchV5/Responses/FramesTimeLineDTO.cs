using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct FramesTimeLineDTO
{
    [JsonProperty("events")] public List<EventsTimeLineDTO> Events { get; set; }
    [JsonProperty("participantFrames")] public Dictionary<int, ParticipantFrameDTO> ParticipantFrames { get; set; }
    [JsonProperty("timestamp")] public int Timestamp { get; set; }
}