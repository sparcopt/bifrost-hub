namespace BifrostHub.Infrastructure.Extensions;

using Microsoft.AspNetCore.Builder;
using Wolverine;

public static class WebApplicationBuilderExtensions
{
    public static ConfigureHostBuilder ConfigureInfra(this ConfigureHostBuilder buidler)
    {
        buidler.UseWolverine(options =>
        {
            options.Discovery.IncludeAssembly(typeof(##).Assembly);
            options.Durability.Mode = DurabilityMode.MediatorOnly;
        });

        return buidler;
    }
}