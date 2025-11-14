using System.Reflection;
using Riot.NET.Enums;

namespace Riot.NET.Attributes;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
internal sealed class RateLimitAttribute(TimeUnit unit, int rule, int limit) : Attribute
{
    public TimeUnit Unit { get; set; } = unit;
    public int Rule { get; set; } = rule;
    public int Limit { get; set; } = limit;
}

internal static partial class PathExtensions
{
    public static Dictionary<TimeSpan, int> GetRateLimits(this Type method)
    {
        var rateLimits = new Dictionary<TimeSpan, int>();

        foreach (var rateLimit in method.GetCustomAttributes<RateLimitAttribute>(false))
        {
            var rule = rateLimit.Unit switch
            {
                TimeUnit.Milliseconds => TimeSpan.FromMilliseconds(rateLimit.Rule),
                TimeUnit.Seconds => TimeSpan.FromSeconds(rateLimit.Rule),
                TimeUnit.Minutes => TimeSpan.FromMinutes(rateLimit.Rule),
                TimeUnit.Hours => TimeSpan.FromHours(rateLimit.Rule),
                TimeUnit.Days => TimeSpan.FromDays(rateLimit.Rule),
                _ => TimeSpan.FromSeconds(rateLimit.Rule)
            };

            rateLimits.Add(rule, rateLimit.Limit);
        }

        return rateLimits;
    }
}