namespace Web.Application.Services;

using Data.Gateway.OdinEye;
using Data.Gateway.Steam;
using Extensions;
using Microsoft.Extensions.Caching.Memory;
using Models;

public class PlayerService : IPlayerService
{
    private readonly IOdinEyeApiClient odinEyeApiClient;
    private readonly ISteamApiClient steamApiClient;
    private readonly IFileService fileService;
    private readonly IMemoryCache steamProfileCache;

    public PlayerService(
        IOdinEyeApiClient odinEyeApiClient,
        ISteamApiClient steamApiClient,
        IFileService fileService,
        IMemoryCache memoryCache)
    {
        this.odinEyeApiClient = odinEyeApiClient;
        this.steamApiClient = steamApiClient;
        this.fileService = fileService;
        steamProfileCache = memoryCache;
    }
    
    public async Task<IEnumerable<Player>> GetPlayers()
    {
        var players = new List<Player>();
        
        foreach (var playerData in await odinEyeApiClient.GetPlayers())
        {
            var player = playerData.ToModel();
            await EnrichPlayerWithSteamProfile(player);
            players.Add(player);
        }

        return players;
    }

    public async Task EnrichPlayerWithSteamProfile(Player player)
    {
        var steamProfile = await GetSteamUserProfile(player.SteamId);
        player.SteamUsername = steamProfile.Profile.Username;
        player.SteamAvatarPath = steamProfile.AvatarImagePath;
    }

    private async Task<SteamUserProfile> GetSteamUserProfile(string steamUserId)
    {
        Console.WriteLine("Getting Steam profile.");
        
        if (!steamProfileCache.TryGetValue(steamUserId, out SteamUserProfile cachedProfile))
        {
            Console.WriteLine("Steam profile cache miss.");
            
            var profile = await steamApiClient.GetUserProfile(steamUserId);
            var avatarFileName = $"{steamUserId}.jpg";
            var steamAvatarPath = await fileService.DownloadRemoteImage(profile.Avatar, avatarFileName, FileService.SteamAvatarFolder);

            cachedProfile = new SteamUserProfile(profile, steamAvatarPath);
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30));
            
            steamProfileCache.Set(steamUserId, cachedProfile, cacheEntryOptions);
        }

        return cachedProfile;
    }
}