namespace BifrostHub.Application.Messaging;

using Features.GameEvents.Dto;

public static class GameEventHandler
{
    public static async Task Handle(GameEvent command)
    {
        await Task.CompletedTask;
    }
}