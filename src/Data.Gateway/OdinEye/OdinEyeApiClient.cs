namespace Data.Gateway.OdinEye;

using global::OdinEye.Models.Api;
using System.Net.Http.Json;

public class OdinEyeApiClient : IOdinEyeApiClient
{
    private readonly HttpClient httpClient;

    public OdinEyeApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<WorldDetails> GetWorldDetails() =>
        await httpClient.GetFromJsonAsync<WorldDetails>("worldDetails");

    public async Task<ServerDetails> GetServerDetails() =>
        await httpClient.GetFromJsonAsync<ServerDetails>("serverDetails");

    public async Task<IEnumerable<Player>> GetPlayers() =>
        await httpClient.GetFromJsonAsync<IEnumerable<Player>>("players");
    
    public async Task<BossDetails> GetBossDetails() =>
        await httpClient.GetFromJsonAsync<BossDetails>("bossDetails");
}