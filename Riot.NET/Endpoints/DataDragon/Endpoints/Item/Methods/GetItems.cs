using Riot.NET.Attributes;
using Riot.NET.Endpoints.DataDragon.Endpoints.Item.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item.Methods;

[Path("/item.json")]
public class GetItems(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonDataMethodBase<ItemListDTO>(endpoint, rateLimiter)
{
}