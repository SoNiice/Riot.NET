using Riot.NET.Attributes;
using Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Champion.Methods;

[Path("/champion.json")]
public class GetChampions(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonDataMethodBase<ChampionListDTO>(endpoint, rateLimiter)
{
}