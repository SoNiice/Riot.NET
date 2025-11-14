using Riot.NET.Attributes;
using Riot.NET.Endpoints.DataDragon.Endpoints.Item.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item.Methods;

[Path("/item-modifiers.json")]
public class GetItemModifiers(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonDataMethodBase<ItemModifierListDTO>(endpoint, rateLimiter)
{
}