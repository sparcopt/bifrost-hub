namespace Web.Application.Services;

using Data.Gateway.OdinEye;
using OdinEye.Models.Proto;
using System.Reactive.Linq;

public class GameActivityConsumerFactory : IGameActivityConsumerFactory
{
    private readonly IOdinEyeWebSocketClient odinEyeWebSocketClient;
    private Dictionary<string, GameActivityConsumer> consumers = new ();
    
    public GameActivityConsumerFactory(IOdinEyeWebSocketClient odinEyeWebSocketClient)
    {
        this.odinEyeWebSocketClient = odinEyeWebSocketClient;
    }

    public IGameActivityConsumer Create(string name)
    {
        if (consumers.TryGetValue(name, out var consumer))
        {
            return consumer;
        }
        
        consumer = new GameActivityConsumer(odinEyeWebSocketClient);
        // Possibility of concurrency
        consumers.TryAdd(name, consumer);
        return consumer;
    }
}

public class GameActivityConsumer : IGameActivityConsumer
{
    private readonly IOdinEyeWebSocketClient odinEyeWebSocketClient;
    private Action<GameEvent> gameEventDelegate;
    private Func<GameEvent, Task> gameEventTaskDelegate;
    private Action<GameStatsSnapshot> gameStatsDelegate;
    private Func<GameStatsSnapshot, Task> gameStatsTaskDelegate;

    public GameActivityConsumer(IOdinEyeWebSocketClient odinEyeWebSocketClient)
    {
        this.odinEyeWebSocketClient = odinEyeWebSocketClient;
        SubscribeActivityObservables();
    }

    public IGameActivityConsumer OnGameEventReceived(Action<GameEvent> handler)
    {
        gameEventDelegate ??= handler;
        return this;
    }

    public IGameActivityConsumer OnGameEventReceived(Func<GameEvent, Task> handler)
    {
        gameEventTaskDelegate ??= handler;
        return this;
    }

    public IGameActivityConsumer OnGameStatsSnapshotReceived(Action<GameStatsSnapshot> handler)
    {
        gameStatsDelegate ??= handler;
        return this;
    }

    public IGameActivityConsumer OnGameStatsSnapshotReceived(Func<GameStatsSnapshot, Task> handler)
    {
        gameStatsTaskDelegate ??= handler;
        return this;
    }

    private void SubscribeActivityObservables()
    {
        SubscribeGameEvents();
        SubscribeGameStatsSnapshots();
    }

    private void SubscribeGameEvents()
    {
        odinEyeWebSocketClient.GameEventReceived
            .Select(gameEvent => Observable.FromAsync(async () =>
            {
                if (gameEventTaskDelegate != null)
                {
                    await gameEventTaskDelegate(gameEvent);
                }
            }))
            .Merge()
            .Subscribe();
        
        odinEyeWebSocketClient.GameEventReceived.Subscribe(gameEvent => gameEventDelegate?.Invoke(gameEvent));
    }
    
    private void SubscribeGameStatsSnapshots()
    {
        odinEyeWebSocketClient.GameStatsSnapshotReceived
            .Select(snapshot => Observable.FromAsync(async () =>
            {
                if (gameStatsTaskDelegate != null)
                {
                    await gameStatsTaskDelegate(snapshot);
                }
            }))
            .Merge()
            .Subscribe();
        
        odinEyeWebSocketClient.GameStatsSnapshotReceived.Subscribe(snapshot => gameStatsDelegate?.Invoke(snapshot));
    }
}