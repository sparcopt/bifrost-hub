namespace BifrostHub.Application.Features.ServerDetails.GetServerDetails;

using Common.Interfaces.Gateways;
using Dto;
using LazyCache;

public class GetServerDetailsQuery
{ }

public static class GetPlayersQueryHandler
{
    private const string CacheKey = "serverDetails";
    
    public static async Task<ServerDetails> Handle(GetServerDetailsQuery query, IOdinEyeApiClient client, IAppCache cache) =>
        await cache.GetOrAddAsync(CacheKey, async entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromMinutes(30);
            return await client.GetServerDetails();
        });
}