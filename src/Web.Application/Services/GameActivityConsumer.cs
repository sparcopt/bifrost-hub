namespace Web.Application.Services;

using Data.Gateway.OdinEye;
using OdinEye.Models.Proto;
using System.Reactive.Linq;

public class GameActivityConsumer : IGameActivityConsumer
{
    private readonly IOdinEyeWebSocketClient odinEyeWebSocketClient;
    private List<IDisposable> subscriptions = new();

    public GameActivityConsumer(IOdinEyeWebSocketClient odinEyeWebSocketClient)
    {
        this.odinEyeWebSocketClient = odinEyeWebSocketClient;
    }

    public IGameActivityConsumer OnGameEventReceived(Action<GameEvent> handler)
    {
        var subscription = odinEyeWebSocketClient.GameEventReceived.Subscribe(handler);
        subscriptions.Add(subscription);
        return this;
    }

    public IGameActivityConsumer OnGameEventReceived(Func<GameEvent, Task> handler)
    {
        var subscription = odinEyeWebSocketClient.GameEventReceived
            .Select(gameEvent => Observable.FromAsync(async () => await handler(gameEvent)))
            .Merge()
            .Subscribe();
        
        subscriptions.Add(subscription);
        return this;
    }

    public IGameActivityConsumer OnGameStatsSnapshotReceived(Action<GameStatsSnapshot> handler)
    {
        var subscription = odinEyeWebSocketClient.GameStatsSnapshotReceived.Subscribe(handler);
        subscriptions.Add(subscription);
        return this;
    }

    public IGameActivityConsumer OnGameStatsSnapshotReceived(Func<GameStatsSnapshot, Task> handler)
    {
        var subscription = odinEyeWebSocketClient.GameStatsSnapshotReceived
            .Select(snapshot => Observable.FromAsync(async () => await handler(snapshot)))
            .Merge()
            .Subscribe();
        
        subscriptions.Add(subscription);
        return this;
    }

    public void Dispose()
    {
        foreach (var subscription in subscriptions)
        {
            subscription.Dispose();
        }
    }
}