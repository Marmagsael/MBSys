using MBApi.StartupConfig;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();
builder.AddApiInjectionServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
