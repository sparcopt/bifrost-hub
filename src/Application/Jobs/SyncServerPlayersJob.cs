namespace BifrostHub.Application.Jobs;

using Common.Interfaces.Gateways;
using Common.Interfaces.Repositories;
using Features.Players.Domain;

public class SyncServerPlayersJob
{
    private readonly IOdinEyeApiClient odinEyeApiClient;
    private readonly IPlayerRepository playerRepository;

    public SyncServerPlayersJob(IOdinEyeApiClient odinEyeApiClient, IPlayerRepository playerRepository)
    {
        this.odinEyeApiClient = odinEyeApiClient;
        this.playerRepository = playerRepository;
    }

    public async Task Execute()
    {
        var onlinePlayers = await odinEyeApiClient.GetPlayers();

        foreach (var onlinePlayer in onlinePlayers)
        {
            var player = await playerRepository.GetById(onlinePlayer.Id);
            if (player is null)
            {
                player = new Player(onlinePlayer.Id, onlinePlayer.Name, onlinePlayer.SteamId);
                await playerRepository.Save(player);
            }
        }
    }
}