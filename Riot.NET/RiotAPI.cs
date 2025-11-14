using Riot.NET.Endpoints.AccountV1;
using Riot.NET.Endpoints.ChampionMasteryV4;
using Riot.NET.Endpoints.ChampionV3;
using Riot.NET.Endpoints.ClashV1;
using Riot.NET.Endpoints.DataDragon;
using Riot.NET.Endpoints.LeagueExpV4;
using Riot.NET.Endpoints.LeagueV4;
using Riot.NET.Endpoints.LolChallengesV1;
using Riot.NET.Endpoints.LolStatusV4;
using Riot.NET.Endpoints.LorMatchV1;
using Riot.NET.Endpoints.LorRankedV1;
using Riot.NET.Endpoints.LorStatusV1;
using Riot.NET.Endpoints.MatchV5;
using Riot.NET.Endpoints.SpectatorTftV5;
using Riot.NET.Endpoints.SpectatorV5;
using Riot.NET.Endpoints.SummonerV4;
using Riot.NET.Endpoints.TournamentStubV5;
using Riot.NET.Endpoints.TournamentV5;
using Riot.NET.Endpoints.ValorantApi;
using Riot.NET.Enums;

namespace Riot.NET;

public class RiotAPI
{
    public readonly DataDragon DataDragon;
    public readonly ValorantApi ValorantApi;
    public readonly AccountV1 AccountV1;
    public readonly ChampionV3 ChampionV3;
    public readonly ChampionMasteryV4 ChampionMasteryV4;
    public readonly ClashV1 ClashV1;
    public readonly LeagueExpV4 LeagueExpV4;
    public readonly LeagueV4 LeagueV4;
    public readonly LolChallengesV1 LolChallengesV1;
    public readonly LolStatusV4 LolStatusV4;
    public readonly LorMatchV1 LorMatchV1;
    public readonly LorRankedV1 LorRankedV1;
    public readonly LorStatusV1 LorStatusV1;
    public readonly MatchV5 MatchV5;
    public readonly SpectatorTftV5 SpectatorTftV5;
    public readonly SpectatorV5 SpectatorV5;
    public readonly SummonerV4 SummonerV4;
    public readonly TournamentStubV5 TournamentStubV5;
    public readonly TournamentV5 TournamentV5;

    public static RiotAPI GetDevelopmentInstance(string apiKey,
        bool throwOnRateLimit = false,
        int rateLimitRetryCount = 3,
        Dictionary<TimeSpan, int>? applicationRateLimits = null,
        Dictionary<RiotMethod, Dictionary<TimeSpan, int>>? methodRateLimits = null)
    {
        applicationRateLimits ??= new()
        {
            [TimeSpan.FromSeconds(1)] = 20,
            [TimeSpan.FromMinutes(2)] = 100
        };

        return new RiotAPI(apiKey, throwOnRateLimit, rateLimitRetryCount, applicationRateLimits, methodRateLimits);
    }

    public static RiotAPI GetInstance(string apiKey,
        bool throwOnRateLimit = false,
        int rateLimitRetryCount = 3,
        Dictionary<TimeSpan, int>? applicationRateLimits = null,
        Dictionary<RiotMethod, Dictionary<TimeSpan, int>>? methodRateLimits = null)
    {
        applicationRateLimits ??= new()
        {
            [TimeSpan.FromSeconds(10)] = 500,
            [TimeSpan.FromMinutes(10)] = 30000
        };

        return new RiotAPI(apiKey, throwOnRateLimit, rateLimitRetryCount, applicationRateLimits, methodRateLimits);
    }

    private RiotAPI(string apiKey, bool throwOnRateLimit, int rateLimitRetryCount, Dictionary<TimeSpan, int> applicationRateLimits, Dictionary<RiotMethod, Dictionary<TimeSpan, int>>? methodRateLimits)
    {
        methodRateLimits ??= new();

        foreach (var method in Enum.GetValues<RiotMethod>())
        {
            if (methodRateLimits.ContainsKey(method))
                continue;

            methodRateLimits[method] = method.GetRateLimits();
        }

        var rateLimiter = new RateLimiter.RateLimiter(apiKey, throwOnRateLimit, rateLimitRetryCount);
        rateLimiter.ConfigureRateLimits(applicationRateLimits, methodRateLimits);

        DataDragon = new DataDragon(rateLimiter);
        ValorantApi = new ValorantApi(rateLimiter);
        AccountV1 = new AccountV1(rateLimiter);
        ChampionV3 = new ChampionV3(rateLimiter);
        ChampionMasteryV4 = new ChampionMasteryV4(rateLimiter);
        ClashV1 = new ClashV1(rateLimiter);
        LeagueExpV4 = new LeagueExpV4(rateLimiter);
        LeagueV4 = new LeagueV4(rateLimiter);
        LolChallengesV1 = new LolChallengesV1(rateLimiter);
        LolStatusV4 = new LolStatusV4(rateLimiter);
        LorMatchV1 = new LorMatchV1(rateLimiter);
        LorRankedV1 = new LorRankedV1(rateLimiter);
        LorStatusV1 = new LorStatusV1(rateLimiter);
        MatchV5 = new MatchV5(rateLimiter);
        SpectatorTftV5 = new SpectatorTftV5(rateLimiter);
        SpectatorV5 = new SpectatorV5(rateLimiter);
        SummonerV4 = new SummonerV4(rateLimiter);
        TournamentStubV5 = new TournamentStubV5(rateLimiter);
        TournamentV5 = new TournamentV5(rateLimiter);
    }
}