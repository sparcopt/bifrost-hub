namespace BifrostHub.Application.Features.Players.GetOnlinePlayers;

using Common.Interfaces.Gateways;
using Dto;
using Steam;

public class GetOnlinePlayersQuery
{ }

public static class GetOnlinePlayersQueryHandler
{
    public static async Task<IEnumerable<OnlinePlayer>> Handle(GetOnlinePlayersQuery query, IOdinEyeApiClient client, ISteamUserProfileService profileService)
    {
        var players = new List<OnlinePlayer>();
        
        foreach (var player in await client.GetPlayers())
        {
            var steamProfile = await profileService.GetSteamUserProfile(player.SteamId);
            player.SetSteamInfo(steamProfile.Username, steamProfile.LocalAvatarImagePath);
            players.Add(player);
        }

        return players;
    }
}