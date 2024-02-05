namespace BifrostHub.Infrastructure.Gateways.OdinEye.Api;

using Application.Common.Interfaces.Gateways;
using Application.Features.Players.Dto;
using Extensions;
using global::OdinEye.Models.Api;
using System.Net.Http.Json;
using BossDetailsDto = Application.Features.BossDetails.Dto.BossDetails;
using Player = global::OdinEye.Models.Api.Player;
using ServerDetailsDto = Application.Features.ServerDetails.Dto.ServerDetails;
using WorldDetailsDto = Application.Features.WorldDetails.Dto.WorldDetails;

public class OdinEyeApiClient : IOdinEyeApiClient
{
    private readonly HttpClient httpClient;

    public OdinEyeApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<WorldDetailsDto> GetWorldDetails()
    {
        var worldDetails = await httpClient.GetFromJsonAsync<WorldDetails>("worldDetails");
        return worldDetails.ToDto();
    }
    
    public async Task<ServerDetailsDto> GetServerDetails()
    {
        var serverDetails = await httpClient.GetFromJsonAsync<ServerDetails>("serverDetails");
        return serverDetails.ToDto();
    }
    
    public async Task<IEnumerable<OnlinePlayer>> GetPlayers()
    {
        var players = await httpClient.GetFromJsonAsync<IEnumerable<Player>>("players");
        return players.Select(p => p.ToDto());
    }
    
    public async Task<BossDetailsDto> GetBossDetails()
    {
        var bossDetails = await httpClient.GetFromJsonAsync<BossDetails>("bossDetails");
        return bossDetails.ToDto();
    }
}