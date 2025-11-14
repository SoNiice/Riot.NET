using System.Reflection;
using Riot.NET.Attributes;
using Riot.NET.Enums;

namespace Riot.NET.Extensions;

internal static class GameExtensions
{
    public static string GetGame(this ShardGame shard)
    {
        return (shard.GetType().GetField(shard.ToString())!.GetCustomAttribute<GameAttribute>(false)!).Game!;
    }

    public static string GetGame(this RegionGame region)
    {
        return (region.GetType().GetField(region.ToString())!.GetCustomAttribute<GameAttribute>(false)!).Game!;
    }
}

internal static class QueueExtensions
{
    public static string GetQueue(this Queue queue)
    {
        return (queue.GetType().GetField(queue.ToString())!.GetCustomAttribute<QueueAttribute>(false)!).Queue!;
    }
}