namespace BifrostHub.Infrastructure.Services;

using Application.Jobs;
using Hangfire;
using Microsoft.Extensions.Hosting;

public class BackgroundJobService : IHostedService
{
    private readonly IBackgroundJobClient backgroundJobClient;

    public BackgroundJobService(IBackgroundJobClient backgroundJobClient)
    {
        this.backgroundJobClient = backgroundJobClient;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        backgroundJobClient.Enqueue<SyncServerPlayersJob>(x => x.Execute());
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}