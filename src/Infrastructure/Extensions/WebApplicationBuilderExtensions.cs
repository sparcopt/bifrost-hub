namespace BifrostHub.Infrastructure.Extensions;

using Application.Common.Interfaces.Gateways;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Wolverine;

public static class WebApplicationBuilderExtensions
{
    public static ConfigureHostBuilder AddInfraDependencies(this ConfigureHostBuilder builder)
    {
        builder
            .UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration)
                .Enrich.WithProperty("Version", context.Configuration["APP_VERSION"]))
            .UseWolverine(options =>
            {
                options.Discovery.IncludeAssembly(typeof(IOdinEyeApiClient).Assembly);
                options.Durability.Mode = DurabilityMode.MediatorOnly;
            });

        return builder;
    }
}