namespace BifrostHub.Application.Common.Interfaces.Gateways;

using Features.Players.Dto;

public interface ISteamApiClient
{
    public Task<SteamUserProfile> GetUserProfile(string steamId);
}