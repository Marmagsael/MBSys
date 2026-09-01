using MBApiLibrary.DataAccess._00_Main;
using MBApiLibrary.DataAccess._00_Main.Interface;
using MBApiLibrary.DataAccess._10_Pis.OPis;
using MBApiLibrary.DataAccess._20_Pay.OPay;
using Microsoft.AspNetCore.DataProtection;
using Radzen;

namespace MBApps.StartupConfig.Library;

public static class _00000OtherServices
{
    public static IServiceCollection Add00000OtherScope(
        this IServiceCollection services,
        IWebHostEnvironment env)
    {
        //--- Data Protection ------------------------------------------
        var keysPath = Path.Combine(env.ContentRootPath, "DataProtectionKeys");

        services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
            .SetApplicationName("MBApps");

        //--- Radzen Requirements ---------------------------------------
        services.AddScoped<DialogService>();
        services.AddScoped<NotificationService>();
        services.AddScoped<TooltipService>();
        services.AddScoped<ContextMenuService>();

        services.AddScoped<IOChartofacctDataAccess, OChartofacctDataAccess>();
        services.AddScoped<I_00MainDataMakerAccess, _00MainDataMakerAccess>();
        services.AddScoped<IOPayrollgrpDataAccess, OPayrollgrpDataAccess>();
        services.AddScoped<IODeprecDataAccess, ODeprecDataAccess>();

        return services;
    }
}