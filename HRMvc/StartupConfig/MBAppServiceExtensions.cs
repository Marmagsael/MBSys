using Blazored.LocalStorage;
using HRMvc.StartupConfig.Library;

namespace HRMvc.StartupConfig;

public static class HRMvcerviceExtensions
{
    public static WebApplicationBuilder AddHRMvcervices(
        this WebApplicationBuilder builder,
        IWebHostEnvironment builderEnvironment)
    {
        builder.AddServices();
        builder.AddInjectServices();
        builder.AddHttpClient();
        builder.AddCors();

        // Authentication
        builder.AddAuthenticationServices();

        // HRMvc Scope
        builder.Services.AddHRMvcScope();

        // Blazored Local Storage
        builder.Services.AddBlazoredLocalStorage();

        // API
        builder.AddApiInjectionServices();
        builder.AddApiServices();

        //--- Library Service --------------------------
        builder.Services.AddAMSScope();
        builder.Services.Add0502Scope();

        builder.Services.Add00000OtherScope(builderEnvironment);
        return builder;
    }
}