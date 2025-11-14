using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Riot.NET.Enums;
using Riot.NET.Extensions;
using MatchType = Riot.NET.Enums.MatchType;

namespace Riot.NET.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class RequestParameterAttribute(int order, string? description = null) : Attribute
{
    public int Order { get; } = order;
    public string? Description { get; } = description;
}

internal interface IAutoUrlFormat
{
    string AutoFormatUrl(string baseUrl, object request);
}

internal static partial class UrlFormatter
{
    public static string FormatBody(object source)
    {
        var type = source.GetType();

        var properties = type.GetProperties()
            .Where(p => p.Name != "Region" && p.Name != "Shard")
            .ToList();

        var propertiesWithAttributes = properties
            .Select(p => new
            {
                Property = p,
                Attribute = p.GetCustomAttribute<BodyParameterAttribute>()
            })
            .Where(x => x.Attribute != null)
            .ToList();

        var orderedProperties = propertiesWithAttributes
            .OrderBy(x => x.Attribute!.Order)
            .Select(x => x.Property)
            .ToList();

        var obj = new JObject();

        foreach (var prop in orderedProperties)
        {
            var value = prop.GetValue(source);
            var jsonPropName = prop.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName ?? prop.Name;
            var propertyConverterAttr = prop.GetCustomAttribute<JsonConverterAttribute>();
            var typeConverterAttr = prop.PropertyType.GetCustomAttribute<JsonConverterAttribute>();

            JsonConverter? converter = null;

            if (propertyConverterAttr != null)
                converter = (JsonConverter)Activator.CreateInstance(propertyConverterAttr.ConverterType)!;
            else if (typeConverterAttr != null)
                converter = (JsonConverter)Activator.CreateInstance(typeConverterAttr.ConverterType)!;

            JToken token;

            if (converter != null)
            {
                var serializer = new JsonSerializer();
                serializer.Converters.Add(converter);

                token = JToken.FromObject(value!, serializer);
            }
            else
            {
                if (value == null)
                    continue;

                token = JToken.FromObject(value);
            }
            obj.Add(jsonPropName, token);
        }

        return obj.ToString(Formatting.None);
    }

    public static string FormatUrl(string baseUrl, object source)
    {
        var type = source.GetType();

        var properties = type.GetProperties()
            .Where(p => p.Name != "Region" && p.Name != "Shard")
            .ToList();

        var propertiesWithAttributes = properties
            .Select(p => new
            {
                Property = p,
                Attribute = p.GetCustomAttribute<RequestParameterAttribute>()
            })
            .Where(x => x.Attribute != null)
            .ToList();

        var orderedProperties = propertiesWithAttributes
            .OrderBy(x => x.Attribute!.Order)
            .Select(x => x.Property)
            .ToList();

        var values = orderedProperties
            .Select(p => p.GetValue(source))
            .Select(FormatValue)
            .ToArray();

        return values.Length == 0 ? baseUrl : string.Format(baseUrl, values);
    }

    public static string FormatStaticUrl(string baseUrl, object source)
    {
        var type = source.GetType();

        var properties = type.GetProperties()
            .Where(p => p.Name != "Version" && p.Name != "Language")
            .ToList();

        var propertiesWithAttributes = properties
            .Select(p => new
            {
                Property = p,
                Attribute = p.GetCustomAttribute<RequestParameterAttribute>()
            })
            .Where(x => x.Attribute != null)
            .ToList();

        var orderedProperties = propertiesWithAttributes
            .OrderBy(x => x.Attribute!.Order)
            .Select(x => x.Property)
            .ToList();

        var values = orderedProperties
            .Select(p => p.GetValue(source))
            .Select(FormatValue)
            .ToArray();

        return values.Length == 0 ? baseUrl : string.Format(baseUrl, values);
    }

    private static object FormatValue(object? value)
    {
        if (value == null)
            return string.Empty;

        return value.GetType().Name switch
        {
            "ShardGame" => ((ShardGame)value).GetGame().ToLower(),
            "RegionGame" => ((RegionGame)value).GetGame().ToLower(),
            "Queue" => ((Queue)value).GetQueue(),
            "Tier" => ((Tier)value).ToString().ToUpper(),
            "Division" => ((Division)value).ToString().ToUpper(),
            "MatchType" => ((MatchType)value).ToString().ToLower(),
            "DateTime" => ((DateTime)value).ToLong().ToString(),
            _ => (value.GetType().IsEnum ? value.ToString()?.ToLower() : value) ?? string.Empty
        };
    }
}