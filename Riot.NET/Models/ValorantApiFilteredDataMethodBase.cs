namespace Riot.NET.Models;

public abstract class ValorantApiFilteredDataMethodBase<TListResponse, TSingleResponse>(string endpoint, RateLimiter.RateLimiter rateLimiter)
    : ValorantApiDataMethodBase<TListResponse>(endpoint, rateLimiter)
    where TListResponse : new()
    where TSingleResponse : new()
{
    public async Task<TSingleResponse> ExecuteWithFilterAsync()
    {
        return ApplyFilter(await base.ExecuteAsync());
    }

    public TSingleResponse ExecuteWithFilter()
    {
        return ApplyFilter(base.Execute());
    }

    protected abstract TSingleResponse ApplyFilter(TListResponse response);
}