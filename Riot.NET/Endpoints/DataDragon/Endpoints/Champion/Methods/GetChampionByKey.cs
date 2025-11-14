using Riot.NET.Attributes;
using Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Methods;

[Path("/champion.json")]
public class GetChampionByKey(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonFilteredDataMethodBase<ChampionListDTO, ChampionDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public int Key { get; set; }

    protected override ChampionDTO ApplyFilter(ChampionListDTO response)
    {
        return response.Data.Values.FirstOrDefault(c => c.Key == Key);
    }
}