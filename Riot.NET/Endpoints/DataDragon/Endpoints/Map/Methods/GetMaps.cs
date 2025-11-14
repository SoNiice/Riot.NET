using Riot.NET.Attributes;
using Riot.NET.Endpoints.DataDragon.Endpoints.Map.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Map.Methods;

[Path("/map.json")]
public class GetMaps(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonDataMethodBase<MapListDTO>(endpoint, rateLimiter)
{
}