namespace BifrostHub.Application.Features.Steam;

using Common.Interfaces.Gateways;
using Files;
using LazyCache;
using Microsoft.Extensions.Logging;
using Players.Dto;

public class SteamUserProfileService : ISteamUserProfileService
{
    private readonly ISteamApiClient steamApiClient;
    private readonly IAppCache steamProfileCache;
    private readonly IFileService fileService;
    private readonly ILogger<SteamUserProfileService> logger;

    public SteamUserProfileService(
        ISteamApiClient steamApiClient,
        IAppCache steamProfileCache,
        IFileService fileService,
        ILogger<SteamUserProfileService>  logger)
    {
        this.steamApiClient = steamApiClient;
        this.steamProfileCache = steamProfileCache;
        this.fileService = fileService;
        this.logger = logger;
    }
    
    public async Task<SteamUserProfile> GetSteamUserProfile(string steamUserId) =>
        await steamProfileCache.GetOrAddAsync(steamUserId, async entry =>
        {
            logger.LogInformation("Steam profile cache miss for steamUserId {SteamUserId}", steamUserId);
            entry.SlidingExpiration = TimeSpan.FromMinutes(30);

            var profile = await steamApiClient.GetUserProfile(steamUserId);
            var steamAvatarPath = await fileService.DownloadRemoteImage(profile.Avatar, steamUserId, FileService.SteamAvatarFolder);
            profile.LocalAvatarImagePath = steamAvatarPath;

            return profile;
        });
}