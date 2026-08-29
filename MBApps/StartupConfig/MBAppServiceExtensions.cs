using Blazored.LocalStorage;
using MBApps.StartupConfig.Library;

namespace MBApps.StartupConfig;

public static class MBAppServiceExtensions
{
    public static WebApplicationBuilder AddMBAppServices(
        this WebApplicationBuilder builder,
        IWebHostEnvironment builderEnvironment)
    {
        builder.AddServices();
        builder.AddInjectServices();
        builder.AddHttpClient();
        builder.AddCors();

        // Authentication
        builder.AddAuthenticationServices();

        // MBApps Scope
        builder.Services.AddMBAppsScope();

        // Blazored Local Storage
        builder.Services.AddBlazoredLocalStorage();

        // API
        builder.AddApiInjectionServices();
        builder.AddApiServices();

        //--- Library Service --------------------------
        builder.Services.Add0502Scope();

        builder.Services.Add00000OtherScope(builderEnvironment);
        return builder;
    }
}