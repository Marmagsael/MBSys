using HRApiLibrary.DataAccess._10_Pis;
using HRApiLibrary.DataAccess._10_Pis.Interface;
using HRApiLibrary.DataAccess._11_AMS;
using HRApiLibrary.Modules._11003AME;
using HRApiLibrary.Modules._11003O;
using HRApiLibrary.Modules._12006O;

namespace HRMvc.StartupConfig.Library;

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
        services.AddScoped<IBioManHourDataAccess, BioManHourDataAccess>();
        services.AddScoped<IBioManHourHdrDataAccess, BioManHourHdrDataAccess>();
        services.AddScoped<IDA_12006O, DA_12006O>();

        return services;
    }
}
