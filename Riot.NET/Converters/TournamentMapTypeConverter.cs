using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Riot.NET.Enums;

namespace Riot.NET.Converters;

internal class TournamentMapTypeConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(long).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
        JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        if (token.Value<string>() == null) return null;
        var str = token.Value<string>();
        switch (str)
        {
            case "SUMMONERS_RIFT":
                return TournamentMapType.SummonersRift;
            case "HOWLING_ABYSS":
                return TournamentMapType.HowlingAbyss;
            default:
                return null;
        }
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var map = (TournamentMapType)value;
        string result;
        switch (map)
        {
            case TournamentMapType.SummonersRift:
                result = "SUMMONERS_RIFT";
                break;
            case TournamentMapType.HowlingAbyss:
                result = "HOWLING_ABYSS";
                break;
            default:
                result = string.Empty;
                break;
        }

        serializer.Serialize(writer, result);
    }
}