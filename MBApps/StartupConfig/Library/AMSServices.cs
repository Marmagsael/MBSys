using MBApiLibrary.DataAccess._10_Pis;
using MBApiLibrary.DataAccess._10_Pis.Interface;
using MBApiLibrary.DataAccess._11_AMS;
using MBApiLibrary.Modules._11003AME;
using MBApiLibrary.Modules._11003O;

namespace MBApps.StartupConfig.Library;

public static class AMSServices
{
    public static IServiceCollection AddAMSScope(this IServiceCollection services)
    {

        services.AddScoped<IAMSTableMaker, AMSTableMaker>();
        services.AddScoped<IAtttemplateDataAccess, AtttemplateDataAccess>();
        services.AddScoped<IAttscheddefaultDataAccess, AttscheddefaultDataAccess>();
        services.AddScoped<IAttscheddailyDataAccess, AttscheddailyDataAccess>();
        services.AddScoped<IAttschedweeklydtlDataAccess, AttschedweeklydtlDataAccess>();
        services.AddScoped<IAttschedweeklyhdrDataAccess, AttschedweeklyhdrDataAccess>();
        services.AddScoped<IAttadvancescheduleDataAccess, AttadvancescheduleDataAccess>();
        services.AddScoped<IDA_11003AME, DA_11003AME>();
        services.AddScoped<IDA_11003O, DA_11003O>();
        services.AddScoped<IAms_otsettingsDataAccess, Ams_otsettingsDataAccess>();
        services.AddScoped<IBiologDataAccess, BiologDataAccess>();

        return services;
    }
}
