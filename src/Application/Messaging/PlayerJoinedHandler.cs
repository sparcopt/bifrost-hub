namespace BifrostHub.Application.Messaging;

using Common.Interfaces.Repositories;
using Features.GameEvents.Dto;
using Domain = Features.Players.Domain;

public static class PlayerJoinedHandler
{
    public static async Task Handle(GameEvent message, IPlayerRepository playerRepository)
    {
        if (message.Type != EventType.PlayerJoin)
        {
            return;
        }

        var player = await playerRepository.GetById(message.Player.Id);
        if (player is { IsOnline: false })
        {
            player.SetAsOnline();
            await playerRepository.Save(player);
        }
        
        if (player is null)
        {
            player = new Domain.Player(message.Player.Id, message.Player.Name, message.Player.SteamId);
            await playerRepository.Save(player);
        }
    }
}