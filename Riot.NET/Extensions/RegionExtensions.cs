using System.Reflection;
using Riot.NET.Attributes;
using Riot.NET.Enums;

namespace Riot.NET.Extensions;

internal static class RegionExtensions
{
    public static string GetRegion(this Shard shard)
    {
        return (shard.GetType().GetField(shard.ToString())!.GetCustomAttribute<RegionAttribute>(false)!).Region!;
    }

    public static string GetRegion(this Region region)
    {
        return (region.GetType().GetField(region.ToString())!.GetCustomAttribute<RegionAttribute>(false)!).Region!;
    }

    public static List<string> GetRegionAlternatives(this Shard shard)
    {
        return (shard.GetType().GetField(shard.ToString())!.GetCustomAttribute<RegionAttribute>(false)!).Alternatives!;
    }

    public static List<string> GetRegionAlternatives(this Region region)
    {
        return (region.GetType().GetField(region.ToString())!.GetCustomAttribute<RegionAttribute>(false)!).Alternatives!;
    }
}