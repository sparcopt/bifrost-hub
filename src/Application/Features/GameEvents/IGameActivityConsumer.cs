namespace BifrostHub.Application.Features.GameEvents;

using Dto;

public interface IGameActivityConsumer : IDisposable
{
    IGameActivityConsumer OnGameEventReceived(Action<GameEvent> handler);
    IGameActivityConsumer OnGameEventReceived(Func<GameEvent, Task> handler);
    IGameActivityConsumer OnGameStatsSnapshotReceived(Func<GameStatsSnapshot, Task> handler);
    IGameActivityConsumer OnGameStatsSnapshotReceived(Action<GameStatsSnapshot> handler);
}