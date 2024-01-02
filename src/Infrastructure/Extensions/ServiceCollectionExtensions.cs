namespace BifrostHub.Infrastructure.Extensions;

using Application.Common.Interfaces.Gateways;
using Configuration;
using Gateways.OdinEye.Api;
using Gateways.OdinEye.WebSockets;
using Gateways.Steam;
using Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services;
using Websocket.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfraDependencies(this IServiceCollection services)
    {
        services
            .AddOptions<OdinEyeOptions>()
            .BindConfiguration(OdinEyeOptions.ConfigSectionPath)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services
            .AddOptions<SteamOptions>()
            .BindConfiguration(SteamOptions.ConfigSectionPath)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services
            .AddLogging()
            .AddLazyCache()
            .AddGateways()
            .AddSingleton<IGameEventLogger, GameEventLogger>()
            .AddHostedService<OdinEyeWebSocketService>();
        
        return services;
    }

    private static IServiceCollection AddGateways(this IServiceCollection services)
    {
        services.AddSingleton<IOdinEyeWebSocketClient>(provider =>
        {
            var logger = provider.GetRequiredService<ILogger<OdinEyeWebSocketClient>>();
            var options = provider.GetRequiredService<IOptions<OdinEyeOptions>>().Value;
            var apiUri = new Uri(options.ApiUrl);
            var webSocketUri = new Uri($"ws://{apiUri.Host}:{apiUri.Port}{options.WebSocketPath}");

            var webSocketClient = new WebsocketClient(webSocketUri);
            webSocketClient.Name = "BifrostHubWsClient";
            webSocketClient.ReconnectTimeout = TimeSpan.FromSeconds(options.WebSocketReconnectTimeout);
            webSocketClient.ErrorReconnectTimeout = TimeSpan.FromSeconds(options.WebSocketErrorReconnectTimeout);
            return new OdinEyeWebSocketClient(webSocketClient, logger);
        });
            
        services.AddHttpClient<IOdinEyeApiClient, OdinEyeApiClient>((provider, client) =>
        {
            var options = provider.GetRequiredService<IOptions<OdinEyeOptions>>().Value;
            client.BaseAddress = new Uri(options.ApiUrl);
        });
            
        services
            .AddTransient<SteamAuthenticationHandler>()
            .AddHttpClient<ISteamApiClient, SteamApiClient>((provider, client) =>
            {
                var options = provider.GetRequiredService<IOptions<SteamOptions>>().Value;
                client.BaseAddress = new Uri(options.ApiUrl); 
            })
            .AddHttpMessageHandler<SteamAuthenticationHandler>();

        return services;
    }
}