using Blazored.LocalStorage;
using MBApps.StartupConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServices();
builder.Services.AddBlazoredLocalStorage();
builder.AddInjectServices();
builder.AddHttpClient();
builder.AddCors();
builder.AddAuthenticationServices();   // Cookie auth
builder.Services.AddMBAppsScope();

// API Injection
builder.AddApiInjectionServices();
builder.AddApiServices();

var app = builder.Build();

app.UseSession();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapBlazorHub();

app.Run();
