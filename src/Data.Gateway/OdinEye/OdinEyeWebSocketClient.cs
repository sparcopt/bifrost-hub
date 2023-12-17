namespace Data.Gateway.OdinEye;

using Extensions;
using global::OdinEye.Models.Proto;
using System.Net.WebSockets;
using System.Reactive.Linq;
using Websocket.Client;

public class OdinEyeWebSocketClient : IOdinEyeWebSocketClient
{
    private readonly IWebsocketClient webSocketClient;
    public IObservable<GameEvent> GameEventReceived { get; private set; }
    public IObservable<GameStatsSnapshot> GameStatsSnapshotReceived { get; private set; }

    public OdinEyeWebSocketClient(IWebsocketClient webSocketClient)
    {
        this.webSocketClient = webSocketClient;
        ConfigureConnectionSubscribers();
        ConfigureMessageObservables();
    }

    public async Task Start() => await webSocketClient.Start();
    
    public async Task Stop()
    {
        await webSocketClient.Stop(WebSocketCloseStatus.NormalClosure, string.Empty);
        webSocketClient.Dispose();
    }
    
    private void ConfigureConnectionSubscribers()
    {
        webSocketClient.ReconnectionHappened.Subscribe(info =>
        {
            Console.WriteLine($"Reconnection happened, type: {info.Type}, url: {webSocketClient.Url}");
        });

        webSocketClient.DisconnectionHappened.Subscribe(info =>
        {
            Console.WriteLine($"Disconnection happened, type: {info.Type}");
        });
    }
    
    private void ConfigureMessageObservables()
    {
        var messageObservable = webSocketClient.MessageReceived
            .Where(message => message.MessageType == WebSocketMessageType.Binary)
            .Select(message => message.Binary.DeserializeProto<Message>());
        
        GameEventReceived = messageObservable
            .Where(message => message is GameEvent)
            .Select(message => (GameEvent)message);

        GameStatsSnapshotReceived = messageObservable
            .Where(message => message is GameStatsSnapshot)
            .Select(message => (GameStatsSnapshot)message);
    }
}