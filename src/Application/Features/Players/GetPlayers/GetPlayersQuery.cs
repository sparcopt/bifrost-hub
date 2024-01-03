namespace BifrostHub.Application.Features.Players.GetPlayers;

using Common.Interfaces.Gateways;
using Dto;
using Steam;

public class GetPlayersQuery
{ }

public static class GetPlayersQueryHandler
{
    public static async Task<IEnumerable<Player>> Handle(GetPlayersQuery query, IOdinEyeApiClient client, ISteamUserProfileService profileService)
    {
        var players = new List<Player>();
        
        foreach (var player in await client.GetPlayers())
        {
            var steamProfile = await profileService.GetSteamUserProfile(player.SteamId);
            player.SetSteamInfo(steamProfile.Username, steamProfile.LocalAvatarImagePath);
            players.Add(player);
        }

        return players;
    }
}