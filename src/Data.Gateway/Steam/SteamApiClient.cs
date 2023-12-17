namespace Data.Gateway.Steam;

using Models;
using System.Net.Http.Json;

public class SteamApiClient : ISteamApiClient
{
    private readonly HttpClient httpClient;

    public SteamApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<UserProfile> GetUserProfile(string steamId) =>
        (await httpClient.GetFromJsonAsync<ResponseResult>($"ISteamUser/GetPlayerSummaries/v0002/?steamids={steamId}")).Response.Players.FirstOrDefault();
}