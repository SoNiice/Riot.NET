namespace Riot.NET.Extensions;

internal static class LongExtensions
{
    private static readonly DateTime BaseDateTime = new(1970, 1, 1);

    public static DateTime ToDateTimeFromMilliSeconds(this long millis)
    {
        return BaseDateTime.AddMilliseconds(millis);
    }
}