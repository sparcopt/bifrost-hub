namespace Data.Gateway.OdinEye;

using global::OdinEye.Models.Api;

public interface IOdinEyeApiClient
{
    public Task<WorldDetails> GetWorldDetails();
    
    public Task<ServerDetails> GetServerDetails();
    
    public Task<IEnumerable<Player>> GetPlayers();
}