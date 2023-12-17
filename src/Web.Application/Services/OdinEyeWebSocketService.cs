namespace Web.Application.Services;

using Data.Gateway.OdinEye;

public class OdinEyeWebSocketService : IHostedService
{
    private readonly IOdinEyeWebSocketClient odinEyeWebSocketClient;

    public OdinEyeWebSocketService(IOdinEyeWebSocketClient odinEyeWebSocketClient)
    {
        this.odinEyeWebSocketClient = odinEyeWebSocketClient;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Starting...");
        await odinEyeWebSocketClient.Start();
        Console.WriteLine("Started.");
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Stopping...");
        await odinEyeWebSocketClient.Stop();
    }
}