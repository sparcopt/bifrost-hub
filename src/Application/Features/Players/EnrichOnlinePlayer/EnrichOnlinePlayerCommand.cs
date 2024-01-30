namespace BifrostHub.Application.Features.Players.EnrichOnlinePlayer;

using Dto;
using Steam;

public class EnrichOnlinePlayerCommand
{
    public OnlinePlayer OnlinePlayer { get; }

    public EnrichOnlinePlayerCommand(OnlinePlayer onlinePlayer)
    {
        OnlinePlayer = onlinePlayer;
    }
}

public static class EnrichOnlinePlayerCommandHandler
{
    public static async Task<OnlinePlayer> Handle(EnrichOnlinePlayerCommand command, ISteamUserProfileService profileService)
    {
        var player = command.OnlinePlayer;
        var steamProfile = await profileService.GetSteamUserProfile(player.SteamId);
        player.SetSteamInfo(steamProfile.Username, steamProfile.LocalAvatarImagePath);

        return player;
    }
}