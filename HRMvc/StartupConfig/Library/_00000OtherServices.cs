using HRApiLibrary.DataAccess._00_Main;
using HRApiLibrary.DataAccess._00_Main.Interface;
using HRApiLibrary.DataAccess._10_Pis;
using HRApiLibrary.DataAccess._10_Pis.Interface;
using HRApiLibrary.DataAccess._10_Pis.OPis;
using HRApiLibrary.DataAccess._20_Pay.OPay;
using HRMvc.DataAccess.Main;
using Microsoft.AspNetCore.DataProtection;
using Radzen;

namespace HRMvc.StartupConfig.Library;

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
            .SetApplicationName("HRMvc");

        //--- Radzen Requirements ---------------------------------------
        services.AddScoped<DialogService>();
        services.AddScoped<NotificationService>();
        services.AddScoped<TooltipService>();
        services.AddScoped<ContextMenuService>();
        services.AddScoped<ClaimsAccess, ClaimsAccess>();


        // --- PIS ------------------------------------------------
        services.AddScoped<IEmpmasInternalDataAccess, EmpmasInternalDataAccess>();
        services.AddScoped<IODeprecDataAccess,      ODeprecDataAccess>();
        services.AddScoped<IAttpunches1DataAccess,  Attpunches1DataAccess>();
        services.AddScoped<IOEmpmasDataAccess,      OEmpmasDataAccess>();
        services.AddScoped<IOEmpportalDataAccess,   OEmpportalDataAccess>();
        services.AddScoped<IOTbltrandtlDataAccess,  OTbltrandtlDataAccess>();
        services.AddScoped<IAttdailyDataAccess,     AttdailyDataAccess>();
        services.AddScoped<I_10_EmpmasDataAccess,   _10_EmpmasDataAccess>();
        services.AddScoped<L12_102>();

        // --- Payrol ------------------------------------------------
        services.AddScoped<IODeprecDataAccess,      ODeprecDataAccess>();      
        services.AddScoped<IOChartofacctDataAccess, OChartofacctDataAccess>();
        services.AddScoped<IOPayrollgrpDataAccess,  OPayrollgrpDataAccess>();
        services.AddScoped<IOLoansDataAccess,       OLoansDataAccess>();
        
        services.AddScoped<I_00MainDataMakerAccess, _00MainDataMakerAccess>();
        
        return services;

    }
}