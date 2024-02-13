namespace BifrostHub.Infrastructure.Extensions;

using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseConfigurableHangfireDashboard(this IApplicationBuilder builder)
    {
        var environment = builder.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
        return environment.IsContinuousIntegration() ? builder : builder.UseHangfireDashboard();
    }
}