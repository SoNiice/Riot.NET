using System.ComponentModel;
using Riot.NET.Attributes;
using Riot.NET.Endpoints.ValorantApi.Endpoints.Agent.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.ValorantApi.Endpoints.Agent.Methods;

[Path("/agents?isPlayableCharacter={0}")]
public class GetAgents(string endpoint, RateLimiter.RateLimiter rateLimiter) : ValorantApiDataMethodBase<AgentsListDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)]
    [DefaultValue(null)]
    public bool? IsPlayableCharacter { get; set; }
}