using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Riot.NET.Enums;
using Riot.NET.Extensions;

namespace Riot.NET.Converters;

internal class QueueConverterFromString : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(long).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        var value = token.Value<string?>();

        if (value == null)
            return null;

        foreach (var queue in Enum.GetValues<Queue>())
        {
            if (string.Equals(queue.GetQueue(), value, StringComparison.OrdinalIgnoreCase))
                return queue;
        }

        return null;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, ((Queue)(value ?? Queue.SoloQ)).GetQueue());
    }
}