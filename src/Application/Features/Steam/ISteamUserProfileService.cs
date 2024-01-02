namespace BifrostHub.Application.Features.Steam;

using Players.Dto;

public interface ISteamUserProfileService
{
    Task<SteamUserProfile> GetSteamUserProfile(string steamUserId);
}