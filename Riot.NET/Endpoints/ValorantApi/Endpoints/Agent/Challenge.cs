using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.ValorantApi.Endpoints.Agent;

[Endpoint("/v1")]
public partial class Agent(RateLimiter.RateLimiter rateLimiter)
{
}