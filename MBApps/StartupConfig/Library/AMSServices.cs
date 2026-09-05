using MBApiLibrary.DataAccess._10_Pis;
using MBApiLibrary.DataAccess._10_Pis.Interface;
using MBApiLibrary.DataAccess._11_AMS;

namespace MBApps.StartupConfig.Library;

public static class AMSServices
{
    public static IServiceCollection AddAMSScope(this IServiceCollection services)
    {

        services.AddScoped<IAMSTableMaker, AMSTableMaker>();
        services.AddScoped<IAtttemplateDataAccess, AtttemplateDataAccess>();


        // Register your scoped services here
        // Example:
        // services.AddScoped<IYourService, YourServiceImplementation>();
        return services;
    }
}
