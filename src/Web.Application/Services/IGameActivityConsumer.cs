namespace Web.Application.Services;

using OdinEye.Models.Proto;

public interface IGameActivityConsumer
{
    IGameActivityConsumer OnGameEventReceived(Action<GameEvent> handler);
    IGameActivityConsumer OnGameEventReceived(Func<GameEvent, Task> handler);
    IGameActivityConsumer OnGameStatsSnapshotReceived(Func<GameStatsSnapshot, Task> handler);
    IGameActivityConsumer OnGameStatsSnapshotReceived(Action<GameStatsSnapshot> handler);
}