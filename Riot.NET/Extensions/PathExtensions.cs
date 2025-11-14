using System.Reflection;
using Riot.NET.Attributes;

namespace Riot.NET.Extensions;

internal static partial class PathExtensions
{
    public static string GetPath(this Type method)
    {
        return method.GetCustomAttribute<PathAttribute>(false)!.Uri!;
    }

    public static HttpMethod GetMethod(this Type method)
    {
        return method.GetCustomAttribute<PathAttribute>(false)!.Method! switch
        {
            "GET" => HttpMethod.Get,
            "POST" => HttpMethod.Post,
            "DELETE" => HttpMethod.Delete,
            "PUT" => HttpMethod.Put,
            _ => HttpMethod.Get
        };
    }
}