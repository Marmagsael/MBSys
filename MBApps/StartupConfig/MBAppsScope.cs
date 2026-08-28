using MBApps.StartupConfig.Library;
using Microsoft.Extensions.DependencyInjection;

namespace MBApps.StartupConfig;

public static class MBAppsScope
{
    public static IServiceCollection AddMBAppsScope(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<SessionService>();
        services.AddScoped<UserClaimsContextService>();

        // TODO: Register your scoped services here
        // services.AddScoped<YourService>();

        return services;
    }
}
