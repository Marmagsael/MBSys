using HRMvc.StartupConfig.Library;
using Microsoft.Extensions.DependencyInjection;

namespace HRMvc.StartupConfig;

public static class HRMvcScope
{
    public static IServiceCollection AddHRMvcScope(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<SessionService>();
        services.AddScoped<UserClaimsContextService>();

        // TODO: Register your scoped services here
        // services.AddScoped<YourService>();

        return services;
    }
}
