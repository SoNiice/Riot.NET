namespace Riot.NET.Extensions;

internal static class DateTimeExtensions
{
    private static readonly DateTime BaseDateTime = new(1970, 1, 1);

    public static long ToLong(this DateTime dateTime)
    {
        var timespan = dateTime - BaseDateTime;
        return (long)timespan.TotalMilliseconds;
    }
}