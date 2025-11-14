using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Riot.NET.Extensions;

namespace Riot.NET.Converters;

internal class DateTimeConverterFromLong : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(long).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var token = JToken.Load(reader);

        if (token.Value<long?>() != null)
            return token.Value<long>().ToDateTimeFromMilliSeconds();

        return null;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, ((DateTime)(value ?? DateTime.MinValue)).ToLong());
    }
}