namespace MBApps.StartupConfig.Library;

public class SessionService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    // TODO: Add session helper methods
    // Example:
    // public string? GetUserId() => _httpContextAccessor.HttpContext?.Session.GetString("UserId");
}
