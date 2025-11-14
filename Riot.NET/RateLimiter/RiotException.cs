using System.Net;

namespace Riot.NET.RateLimiter;

public class RiotException(string message, HttpStatusCode httpStatusCode) : Exception($"[{httpStatusCode}] {message}")
{
    public readonly HttpStatusCode HttpStatusCode = httpStatusCode;
}