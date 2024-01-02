namespace BifrostHub.Application.Extensions;

using Features.Files;
using Features.GameEvents;
using Features.Steam;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<ISteamUserProfileService, SteamUserProfileService>();
        services.AddTransient<IGameActivityConsumer, GameActivityConsumer>();
        return services;
    }
}