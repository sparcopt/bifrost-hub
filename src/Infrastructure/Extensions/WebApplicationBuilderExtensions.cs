namespace BifrostHub.Infrastructure.Extensions;

using Application.Common.Interfaces.Gateways;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Wolverine;

public static class WebApplicationBuilderExtensions
{
    public static ConfigureHostBuilder AddInfraDependencies(this ConfigureHostBuilder builder, Type applicationAssemblyType)
    {
        builder
            .UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration)
                .Enrich.WithProperty("Version", context.Configuration["APP_VERSION"]))
            .UseWolverine(options =>
            {
                options.ApplicationAssembly = applicationAssemblyType.Assembly;
                
                // Uses TypeLoadMode.Auto on Development environment
                // Uses TypeLoadMode.Static on every other environment
                options.OptimizeArtifactWorkflow();
                
                options.Discovery.IncludeAssembly(typeof(IOdinEyeApiClient).Assembly);
                options.Durability.Mode = DurabilityMode.MediatorOnly;
            });

        return builder;
    }
}