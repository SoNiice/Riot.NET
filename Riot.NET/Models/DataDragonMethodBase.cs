using Riot.NET.Attributes;
using Riot.NET.Enums;
using Riot.NET.Extensions;

namespace Riot.NET.Models;

public abstract class DataDragonMethodBase<TResponse>(string endpoint, RateLimiter.RateLimiter limiter) : MethodBase<TResponse>(endpoint, limiter)
    where TResponse : new()
{
    protected override (string region, string formattedUrl) FormatUrlAndGetRegion()
    {
        var formattedUrl = UrlFormatter.FormatStaticUrl(Url, this);

        return (string.Empty, formattedUrl);
    }

    public override async Task<TResponse> ExecuteAsync()
    {
        var (region, formattedUrl) = FormatUrlAndGetRegion();

        var response = await RateLimiter.SendAsync(HttpMethod.Get, region, "https://ddragon.leagueoflegends.com" + Url, formattedUrl, string.Empty, string.Empty,false);
        var json = await response.Content.ReadAsStringAsync();

        return DeserializeResponse(json);
    }
}