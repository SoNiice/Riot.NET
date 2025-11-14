using Riot.NET.Endpoints.DataDragon.Endpoints.Challenge;
using Riot.NET.Endpoints.DataDragon.Endpoints.Champion;
using Riot.NET.Endpoints.DataDragon.Endpoints.Item;
using Riot.NET.Endpoints.DataDragon.Endpoints.Map;
using Riot.NET.Endpoints.ValorantApi.Endpoints.Agent;
using Version = Riot.NET.Endpoints.DataDragon.Endpoints.Version.Version;

namespace Riot.NET.Endpoints.ValorantApi;

public class ValorantApi(RateLimiter.RateLimiter rateLimiter)
{
    public readonly Agent Agent = new Agent(rateLimiter);
}