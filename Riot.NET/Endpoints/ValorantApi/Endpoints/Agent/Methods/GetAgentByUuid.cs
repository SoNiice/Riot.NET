using System.ComponentModel;
using Riot.NET.Attributes;
using Riot.NET.Endpoints.ValorantApi.Endpoints.Agent.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.ValorantApi.Endpoints.Agent.Methods;

[Path("/agents")]
public class GetAgentByUuid(string endpoint, RateLimiter.RateLimiter rateLimiter) : ValorantApiFilteredDataMethodBase<AgentsListDTO, AgentDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public Guid Uuid { get; set; }

    protected override AgentDTO ApplyFilter(AgentsListDTO response)
    {
        return response.Data.FirstOrDefault(a => a.Uuid == Uuid);
    }
}