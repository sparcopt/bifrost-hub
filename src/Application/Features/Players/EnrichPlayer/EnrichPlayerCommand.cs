namespace BifrostHub.Application.Features.Players.EnrichPlayer;

using Dto;
using Steam;

public class EnrichPlayerCommand
{
    public Player Player { get; set; }
}

public static class EnrichPlayerCommandHandler
{
    public static async Task<Player> Handle(EnrichPlayerCommand command, ISteamUserProfileService profileService)
    {
        var player = command.Player;
        var steamProfile = await profileService.GetSteamUserProfile(player.SteamId);
        player.SetSteamInfo(steamProfile.Username, steamProfile.LocalAvatarImagePath);

        return player;
    }
}