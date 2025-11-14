namespace Riot.NET.RateLimiter;

internal class RateLimitRule(TimeSpan rule, int limit)
{
    public TimeSpan Rule { get; } = rule;
    public int Limit { get; } = limit;
    private readonly Queue<DateTime> _requestTimestamps = new();

    public bool TryConsume(out TimeSpan retryAfter)
    {
        var now = DateTime.UtcNow;

        while (_requestTimestamps.Count > 0 && (now - _requestTimestamps.Peek()) > Rule)
            _requestTimestamps.Dequeue();

        if (_requestTimestamps.Count < Limit)
        {
            _requestTimestamps.Enqueue(now);
            retryAfter = TimeSpan.Zero;
            return true;
        }

        retryAfter = Rule - (now - _requestTimestamps.Peek());
        return false;
    }
}