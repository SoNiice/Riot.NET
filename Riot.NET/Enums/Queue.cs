using Riot.NET.Attributes;

namespace Riot.NET.Enums;

public enum Queue
{
    [Queue("RANKED_SOLO_5x5")] SoloQ,
    [Queue("RANKED_FLEX_SR")] FlexQ,
    [Queue("RANKED_TFT")] TFT
}