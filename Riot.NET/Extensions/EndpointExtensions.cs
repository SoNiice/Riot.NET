using System.Reflection;
using Riot.NET.Attributes;

namespace Riot.NET.Extensions;

internal static class EndpointExtensions
{
    public static string GetEndpoint(this Type endpoint)
    {
        return endpoint.GetCustomAttribute<EndpointAttribute>(false)!.Uri!;
    }
}