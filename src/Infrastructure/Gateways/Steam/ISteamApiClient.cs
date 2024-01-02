namespace BifrostHub.Infrastructure.Gateways.Steam;

using Models;

public interface ISteamApiClient
{
    public Task<UserProfile> GetUserProfile(string steamId);
}