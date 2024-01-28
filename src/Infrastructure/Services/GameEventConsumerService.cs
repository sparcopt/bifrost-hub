namespace BifrostHub.Infrastructure.Services;

using Application.Common.Interfaces.Gateways;
using Microsoft.Extensions.Hosting;
using System.Reactive.Linq;
using Wolverine;

public class GameEventConsumerService : IHostedService
{
    private readonly IOdinEyeWebSocketClient odinEyeWebSocketClient;
    private readonly IMessageBus mediator;

    public GameEventConsumerService(IOdinEyeWebSocketClient odinEyeWebSocketClient, IMessageBus mediator)
    {
        this.odinEyeWebSocketClient = odinEyeWebSocketClient;
        this.mediator = mediator;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        odinEyeWebSocketClient.GameEventReceived
            .Select(gameEvent => Observable.FromAsync(async () => await mediator.InvokeAsync(gameEvent)))
            .Merge()
            .Subscribe();
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}