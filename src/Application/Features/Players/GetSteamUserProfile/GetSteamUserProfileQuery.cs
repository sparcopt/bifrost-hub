namespace BifrostHub.Application.Features.Players.GetSteamUserProfile;

using Dto;
using Steam;

public class GetSteamUserProfileQuery
{
    public string SteamId { get; set; }
}

public static class GetSteamUserProfileQueryHandler
{
    public static async Task<SteamUserProfile> Handle(GetSteamUserProfileQuery query, ISteamUserProfileService profileService) =>
        await profileService.GetSteamUserProfile(query.SteamId);
}