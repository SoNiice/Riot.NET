using Riot.NET.Attributes;
using Riot.NET.Endpoints.DataDragon.Endpoints.Item.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item.Methods;

[Path("/item.json")]
public class GetItemById(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonFilteredDataMethodBase<ItemListDTO, ItemDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public int Id { get; set; }

    protected override ItemDTO ApplyFilter(ItemListDTO response)
    {
        return response.Data.FirstOrDefault(i => i.Key == Id).Value;
    }
}