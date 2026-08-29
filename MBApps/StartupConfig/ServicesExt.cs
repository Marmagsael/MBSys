namespace MBApps.StartupConfig;

public static class ServicesExt
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddTelerikBlazor();
        builder.Services.AddSession();
        builder.Services.AddMemoryCache();
    }
    public static void AddInjectServices(this WebApplicationBuilder builder)
    {
        // TODO: Register shared injectable services
    }
    public static void AddHttpClient(this WebApplicationBuilder builder)
    {
        string apiAddress = builder.Configuration.GetSection("ApiAddress").Value ?? "https://localhost:22700/api/";

        builder.Services.AddHttpClient("MBAppsApi", client =>
        {
            client.BaseAddress = new Uri(apiAddress);
        });

        builder.Services.AddScoped(sp =>
            sp.GetRequiredService<IHttpClientFactory>().CreateClient("MBAppsApi"));
    }
    public static void AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });
    }
}
