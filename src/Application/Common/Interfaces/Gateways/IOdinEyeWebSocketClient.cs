namespace BifrostHub.Application.Common.Interfaces.Gateways;

using Features.GameEvents.Dto;

public interface IOdinEyeWebSocketClient
{
    IObservable<GameEvent> GameEventReceived { get; }
    IObservable<GameStatsSnapshot> GameStatsSnapshotReceived { get; }
    Task Start();
    Task Stop();
}