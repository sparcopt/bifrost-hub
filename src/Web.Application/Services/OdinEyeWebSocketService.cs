namespace Web.Application.Services;

using Data.Gateway.OdinEye;

public class OdinEyeWebSocketService : IHostedService
{
    private readonly IOdinEyeWebSocketClient odinEyeWebSocketClient;
    private readonly ILogger<OdinEyeWebSocketService> logger;

    public OdinEyeWebSocketService(IOdinEyeWebSocketClient odinEyeWebSocketClient, ILogger<OdinEyeWebSocketService> logger)
    {
        this.odinEyeWebSocketClient = odinEyeWebSocketClient;
        this.logger = logger;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting WebSocket client");
        await odinEyeWebSocketClient.Start();
        logger.LogInformation("WebSocket client running");
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("WebSocket client stopping");
        await odinEyeWebSocketClient.Stop();
    }
}