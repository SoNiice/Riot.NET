using Riot.NET.Attributes;

namespace Riot.NET.Endpoints.AccountV1;

[Endpoint("/riot/account/v1")]
public partial class AccountV1(RateLimiter.RateLimiter rateLimiter)
{
}