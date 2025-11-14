using Riot.NET.Attributes;
using Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Responses;
using Riot.NET.Models;

namespace Riot.NET.Endpoints.DataDragon.Endpoints.Challenge.Methods;

[Path("/challenges.json")]
public class GetChallengeById(string endpoint, RateLimiter.RateLimiter rateLimiter) : DataDragonFilteredDataMethodBase<List<ChallengeDTO>, ChallengeDTO>(endpoint, rateLimiter)
{
    [RequestParameter(0)] public int Id { get; set; }

    protected override ChallengeDTO ApplyFilter(List<ChallengeDTO> response)
    {
        return response.FirstOrDefault(c => c.Id == Id);
    }
}