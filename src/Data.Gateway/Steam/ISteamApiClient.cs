namespace Data.Gateway.Steam;

using Models;

public interface ISteamApiClient
{
    public Task<UserProfile> GetUserProfile(string steamId);
}