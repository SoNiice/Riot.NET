using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Item;

[Endpoint("/cdn")]
public partial class Item(RateLimiter.RateLimiter rateLimiter)
{
}