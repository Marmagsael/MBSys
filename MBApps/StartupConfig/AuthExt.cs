using Microsoft.AspNetCore.Authentication.Cookies;

namespace MBApps.StartupConfig;

public static class AuthExt
{
    public static void AddAuthenticationServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath        = "/login";
                options.LogoutPath       = "/logout";
                options.AccessDeniedPath = "/login";
                options.ExpireTimeSpan   = TimeSpan.FromMinutes(
                    int.Parse(builder.Configuration
                        .GetSection("Authentication:SecondsExpires").Value ?? "1200") / 60
                );
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly   = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite   = SameSiteMode.Strict;
            });

        builder.Services.AddAuthorization();
    }
}
