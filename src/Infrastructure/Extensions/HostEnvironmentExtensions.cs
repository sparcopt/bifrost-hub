namespace BifrostHub.Infrastructure.Extensions;

using Microsoft.Extensions.Hosting;

public static class HostEnvironmentExtensions
{
    private const string ContinuousIntegration = "CI";

    public static bool IsContinuousIntegration(this IHostEnvironment hostEnvironment) =>
        hostEnvironment.IsEnvironment(ContinuousIntegration);
}