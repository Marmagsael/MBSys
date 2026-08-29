using MBApps.StartupConfig;

var builder = WebApplication.CreateBuilder(args);
builder.AddMBAppServices(builder.Environment);

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