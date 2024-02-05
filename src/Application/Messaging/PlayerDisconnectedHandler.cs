namespace BifrostHub.Application.Messaging;

using Common.Interfaces.Repositories;
using Features.GameEvents.Dto;

public class PlayerDisconnectedHandler
{
    public static async Task Handle(GameEvent message, IPlayerRepository playerRepository)
    {
        if (message.Type != EventType.PlayerDisconnect)
        {
            return;
        }

        var player = await playerRepository.GetById(message.Player.Id);
        player.SetAsOffline();
        await playerRepository.Save(player);
    }
}