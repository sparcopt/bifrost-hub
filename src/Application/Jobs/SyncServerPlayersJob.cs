namespace BifrostHub.Application.Jobs;

using Common.Interfaces.Gateways;
using Common.Interfaces.Repositories;
using Features.Players.Domain;
using Microsoft.Extensions.Logging;

public class SyncServerPlayersJob
{
    private readonly IOdinEyeApiClient odinEyeApiClient;
    private readonly IPlayerRepository playerRepository;
    private readonly ILogger<SyncServerPlayersJob> logger;

    public SyncServerPlayersJob(IOdinEyeApiClient odinEyeApiClient, IPlayerRepository playerRepository, ILogger<SyncServerPlayersJob> logger)
    {
        this.odinEyeApiClient = odinEyeApiClient;
        this.playerRepository = playerRepository;
        this.logger = logger;
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
                logger.LogDebug("Saving player {Name} with {Id}", player.Name, player.Id);
                await playerRepository.Save(player);
            }
        }
    }
}