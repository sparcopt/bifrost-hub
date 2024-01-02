namespace BifrostHub.Infrastructure.Gateways.OdinEye.WebSockets;

using Application.Common.Interfaces.Gateways;
using Extensions;
using global::OdinEye.Models.Proto;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;
using System.Reactive.Linq;
using Websocket.Client;
using GameEvent = Application.Features.GameEvents.Dto.GameEvent;
using GameStatsSnapshot = Application.Features.GameEvents.Dto.GameStatsSnapshot;

public class OdinEyeWebSocketClient : IOdinEyeWebSocketClient
{
    private readonly IWebsocketClient webSocketClient;
    private readonly ILogger<OdinEyeWebSocketClient> logger;
    public IObservable<GameEvent> GameEventReceived { get; private set; }
    public IObservable<GameStatsSnapshot> GameStatsSnapshotReceived { get; private set; }

    public OdinEyeWebSocketClient(IWebsocketClient webSocketClient, ILogger<OdinEyeWebSocketClient> logger)
    {
        this.webSocketClient = webSocketClient;
        this.logger = logger;
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
            logger.LogInformation("Reconnection happened, type: {Type}, url: {Url}", info.Type, webSocketClient.Url);
        });

        webSocketClient.DisconnectionHappened.Subscribe(info =>
        {
            logger.LogWarning("Disconnection happened, type: {Type}", info.Type);
        });
    }
    
    private void ConfigureMessageObservables()
    {
        var messageObservable = webSocketClient.MessageReceived
            .Where(message => message.MessageType == WebSocketMessageType.Binary)
            .Select(message => message.Binary.DeserializeProto<Message>());
        
        GameEventReceived = messageObservable
            .Where(message => message is global::OdinEye.Models.Proto.GameEvent)
            .Select(message => ((global::OdinEye.Models.Proto.GameEvent)message).ToDto());

        GameStatsSnapshotReceived = messageObservable
            .Where(message => message is global::OdinEye.Models.Proto.GameStatsSnapshot)
            .Select(message => ((global::OdinEye.Models.Proto.GameStatsSnapshot)message).ToDto());
    }
}