using Newtonsoft.Json;

namespace Riot.NET.Endpoints.ValorantApi.Endpoints.Agent.Responses;

public struct AgentsListDTO
{
    [JsonProperty("status")] public long Status { get; set; }
    [JsonProperty("data")] public List<AgentDTO> Data { get; set; }
}