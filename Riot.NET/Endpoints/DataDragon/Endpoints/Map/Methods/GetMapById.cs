using Riot.NET.Attributes;
using Riot.NET.Endpoints.DataDragon.Endpoints.Map.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Map.Methods;

[Path("/map.json")]
public class GetMapById(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonFilteredDataMethodBase<MapListDTO, MapDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public int Id { get; set; }

    protected override MapDTO ApplyFilter(MapListDTO response)
    {
        return response.Data.FirstOrDefault(i => i.Key == Id).Value;
    }
}