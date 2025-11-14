using Riot.NET.Endpoints.DataDragon.Endpoints.Challenge;
using Riot.NET.Endpoints.DataDragon.Endpoints.Champion;
using Riot.NET.Endpoints.DataDragon.Endpoints.Item;
using Riot.NET.Endpoints.DataDragon.Endpoints.Map;
using Version = Riot.NET.Endpoints.DataDragon.Endpoints.Version.Version;

namespace Riot.NET.Endpoints.DataDragon;

public class DataDragon(RateLimiter.RateLimiter rateLimiter)
{
    public readonly Version Version = new Version(rateLimiter);
    public readonly Challenge Challenge = new Challenge(rateLimiter);
    public readonly Champion Champion = new Champion(rateLimiter);
    public readonly Item Item = new Item(rateLimiter);
    public readonly Map Map = new Map(rateLimiter);
}