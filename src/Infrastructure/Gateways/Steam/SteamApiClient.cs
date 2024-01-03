namespace BifrostHub.Infrastructure.Gateways.Steam;

using Application.Common.Interfaces.Gateways;
using Application.Features.Players.Dto;
using Extensions;
using Models;
using System.Net.Http.Json;

public class SteamApiClient : ISteamApiClient
{
    private readonly HttpClient httpClient;

    public SteamApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<SteamUserProfile> GetUserProfile(string steamId)
    {
        var response = await httpClient.GetFromJsonAsync<Response<PlayerSummaryResponse>>($"ISteamUser/GetPlayerSummaries/v0002/?steamids={steamId}");
        return response.Data.Players.FirstOrDefault().ToDto();
    }
}