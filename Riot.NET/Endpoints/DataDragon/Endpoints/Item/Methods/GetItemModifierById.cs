using Riot.NET.Attributes;
using Riot.NET.Endpoints.DataDragon.Endpoints.Item.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item.Methods;

[Path("/item-modifiers.json")]
public class GetItemModifierById(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonFilteredDataMethodBase<ItemModifierListDTO, ItemModifierDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public long Id { get; set; }

    protected override ItemModifierDTO ApplyFilter(ItemModifierListDTO response)
    {
        return response.Data.FirstOrDefault(i => i.Key == Id).Value;
    }
}