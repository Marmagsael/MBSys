using MBApiLibrary.DataAccess._10_Pis;
using MBApiLibrary.DataAccess._10_Pis.Interface;

namespace MBApps.StartupConfig.Library; 

public static class _0502Services
{
    public static IServiceCollection Add0502Scope(this IServiceCollection services)
    {

        services.AddScoped<IDeviationDataAccess, DeviationDataAccess>();


        return services; 
    }
}
