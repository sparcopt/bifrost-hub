namespace BifrostHub.Application.Common.Interfaces.Gateways;

using Features.BossDetails.Dto;
using Features.Players.Dto;
using Features.ServerDetails.Dto;
using Features.WorldDetails.Dto;

public interface IOdinEyeApiClient
{
    public Task<WorldDetails> GetWorldDetails();
    
    public Task<ServerDetails> GetServerDetails();
    
    public Task<IEnumerable<Player>> GetPlayers();

    public Task<BossDetails> GetBossDetails();
}