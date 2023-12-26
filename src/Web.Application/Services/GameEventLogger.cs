namespace Web.Application.Services;

using Data.Gateway.OdinEye;

public class GameEventLogger : IGameEventLogger
{
    private readonly IOdinEyeWebSocketClient odinEyeWebSocketClient;
    private readonly ILogger<GameEventLogger> logger;

    public GameEventLogger(IOdinEyeWebSocketClient odinEyeWebSocketClient, ILogger<GameEventLogger> logger)
    {
        this.odinEyeWebSocketClient = odinEyeWebSocketClient;
        this.logger = logger;
    }

    public void Start()
    {
        odinEyeWebSocketClient.GameEventReceived.Subscribe(gameEvent =>
        {
            var scopeProperty = new Dictionary<string, object> { { "@GameEvent", gameEvent } };
            using (logger.BeginScope(scopeProperty))
            {
                logger.LogDebug("Game event received: {GameEventMessage}", gameEvent.Message);
            }
        });
    }
}