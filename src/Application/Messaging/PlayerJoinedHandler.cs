namespace BifrostHub.Application.Messaging;

using Common.Interfaces.Repositories;
using Features.GameEvents.Dto;
using Microsoft.Extensions.Logging;
using Domain = Features.Players.Domain;

public static class PlayerJoinedHandler
{
    public static async Task Handle(GameEvent message, IPlayerRepository playerRepository, ILogger<GameEvent> logger)
    {
        logger.LogInformation("Entering PlayerJoinedHandler");
        
        if (message.Type != EventType.PlayerJoin)
        {
            logger.LogInformation("Event type is {Type}. Skipping!", message.Type);
            return;
        }

        logger.LogInformation("Getting player from DB");
        var player = await playerRepository.GetById(message.Player.Id);
        if (player is { IsOnline: false })
        {
            logger.LogInformation("Setting existing player {Name} to online", player.Name);
            player.SetAsOnline();
            await playerRepository.Save(player);
        }
        
        if (player is null)
        {
            logger.LogInformation("Creating new player {Name}", message.Player.Name);
            player = new Domain.Player(message.Player.Id, message.Player.Name, message.Player.SteamId);
            await playerRepository.Save(player);
        }
        
        logger.LogInformation("Exiting PlayerJoinedHandler");
    }
}