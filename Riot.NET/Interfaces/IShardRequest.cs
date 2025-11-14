using Riot.NET.Enums;

namespace Riot.NET.Interfaces;

public interface IShardRequest
{
    Shard Shard { get; }
}