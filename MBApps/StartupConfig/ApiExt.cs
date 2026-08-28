using MBApiLibrary.DataAccess._00_Login;
using MBApiLibrary.DataAccess._00_Login.Interface;
using MBApiLibrary.DataAccess._00_Main;
using MBApiLibrary.DataAccess._00_Main.Interface;
using MBApiLibrary.DataAccess._20_Pay;
using MBApiLibrary.DataAccess._20_Pay.Interface;
using MBApiLibrary.DataAccess._90_Utils;
using MBApiLibrary.DataAccess._90_Utils.Interface;

namespace MBApps.StartupConfig;

public static class ApiExt
{
    public static void AddApiServices(this WebApplicationBuilder builder)   {   builder.Services.AddSwaggerGen(); }
    public static void AddApiInjectionServices(this WebApplicationBuilder builder)
    {
        // Core
        builder.Services.AddScoped<I_90_001_MySqlDataAccess, _90_001_MySqlDataAccess>();
        builder.Services.AddScoped<I_09_02_VarsGlobal, _09_02_VarsGlobal>();

        // Login
        builder.Services.AddScoped<I_00_001_LoginAccess, _00_001_LoginAccess>();
        builder.Services.AddScoped<IMainmenuDataAccess, MainmenuDataAccess>();


        // Main DA (Users, UserCompany, CompanyUsers, Country, City, etc.)
        builder.Services.AddScoped<I_00MainDA, _00MainDA>();
        builder.Services.AddScoped<I_00UsersAccess, _00UsersAccess>();
        builder.Services.AddScoped<I_00UserscompanyDataAccess, _00UserscompanyDataAccess>();
        builder.Services.AddScoped<I_00CompanyusersDataAccess, _00CompanyusersDataAccess>();

        // MainPis (Empmas)
        builder.Services.AddScoped<I_00MainPisAccess, _00MainPisAccess>();
        builder.Services.AddScoped<I_00MainPisTblMakerAccess, _00MainPisTblMakerAccess>();

        // Pay Table Maker
        builder.Services.AddScoped<I_20_002_PayTblMaker, _20_002_PayTblMaker>();

        // Accounting Table Maker
        builder.Services.AddScoped<I_AcctgTableMaker, _AcctgTableMaker>();
    }
}