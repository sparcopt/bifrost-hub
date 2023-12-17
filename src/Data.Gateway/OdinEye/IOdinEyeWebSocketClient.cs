namespace Data.Gateway.OdinEye;

using global::OdinEye.Models.Proto;

public interface IOdinEyeWebSocketClient
{
    IObservable<GameEvent> GameEventReceived { get; }
    IObservable<GameStatsSnapshot> GameStatsSnapshotReceived { get; }
    Task Start();
    Task Stop();
}