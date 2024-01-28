namespace BifrostHub.Application.Messaging;

using Common.Interfaces.Repositories;
using Features.GameEvents.Dto;

public static class PlayerJoinedHandler
{
    public static async Task Handle(GameEvent message, IPlayerRepository playerRepository)
    {
        if (message.Type != EventType.PlayerJoin)
        {
            return;
        }
        
        await Task.CompletedTask;
    }
}