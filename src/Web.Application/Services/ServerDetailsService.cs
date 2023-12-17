namespace Web.Application.Services;

using Data.Gateway.OdinEye;
using Microsoft.Extensions.Caching.Memory;
using OdinEye.Models.Api;

public class ServerDetailsService : IServerDetailsService
{
    private readonly IOdinEyeApiClient odinEyeApiClient;
    private readonly IMemoryCache serverDetailsCache;
    private const string CacheKey = "serverDetails";

    public ServerDetailsService(IOdinEyeApiClient odinEyeApiClient, IMemoryCache serverDetailsCache)
    {
        this.odinEyeApiClient = odinEyeApiClient;
        this.serverDetailsCache = serverDetailsCache;
    }

    public async Task<ServerDetails> GetServerDetails()
    {
        if (!serverDetailsCache.TryGetValue(CacheKey, out ServerDetails serverDetails))
        {
            serverDetails = await odinEyeApiClient.GetServerDetails();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30));
            
            serverDetailsCache.Set(CacheKey, serverDetails, cacheEntryOptions);
        }

        return serverDetails;
    }
}