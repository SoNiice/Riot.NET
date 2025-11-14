using System.Globalization;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Riot.NET.Converters;

internal class DateTimeConverterFromStringTimestampLong : JsonConverter
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

        return DateTime.ParseExact(value, "ddd MMM dd HH:mm:ss 'UTC' yyyy", CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, ((DateTime)(value ?? DateTime.MinValue)).ToString("ddd MMM dd HH:mm:ss 'UTC' yyyy"));
    }
}