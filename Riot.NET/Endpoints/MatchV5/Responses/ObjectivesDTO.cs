using Newtonsoft.Json;

namespace Riot.NET.Endpoints.MatchV5.Responses;

public struct ObjectivesDTO
{
    [JsonProperty("atakhan")] public ObjectiveDTO Atakhan { get; set; }
    [JsonProperty("baron")] public ObjectiveDTO Baron { get; set; }
    [JsonProperty("champion")] public ObjectiveDTO Champion { get; set; }
    [JsonProperty("dragon")] public ObjectiveDTO Dragon { get; set; }
    [JsonProperty("horde")] public ObjectiveDTO Horde { get; set; }
    [JsonProperty("inhibitor")] public ObjectiveDTO Inhibitor { get; set; }
    [JsonProperty("riftHerald")] public ObjectiveDTO RiftHerald { get; set; }
    [JsonProperty("tower")] public ObjectiveDTO Tower { get; set; }
}