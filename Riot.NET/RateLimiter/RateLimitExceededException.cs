namespace Riot.NET.RateLimiter;

public class RateLimitExceededException(RateLimitScope scope, string region, string method, int currentCount, TimeSpan retryAfter)
    : Exception($"Rate limit exceeded for {scope} in region {region} (method: {method}) - {currentCount} requests. Retry after {retryAfter.TotalSeconds} seconds.")
{
    public RateLimitScope Scope { get; } = scope;
    public string Region { get; } = region;
    public string Method { get; } = method;
    public int CurrentCount { get; } = currentCount;
    public TimeSpan RetryAfter { get; } = retryAfter;
}