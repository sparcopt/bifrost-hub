namespace BifrostHub.Infrastructure.Extensions;

using Application.Common.Interfaces.Gateways;
using Microsoft.AspNetCore.Builder;
using Wolverine;

public static class WebApplicationBuilderExtensions
{
    public static ConfigureHostBuilder ConfigureInfra(this ConfigureHostBuilder buidler)
    {
        buidler.UseWolverine(options =>
        {
            options.Discovery.IncludeAssembly(typeof(IOdinEyeApiClient).Assembly);
            options.Durability.Mode = DurabilityMode.MediatorOnly;
        });

        return buidler;
    }
}