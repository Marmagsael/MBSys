using System.Security.Claims;

namespace MBApps.StartupConfig.Library;

/// <summary>
/// Reads cookie claims and builds a UserClaimsModel.
/// Usage in .cshtml: var uc = _claimsContext.Build(User);
/// Usage in .razor:  [Parameter] public UserClaimsModel? UserClaims { get; set; }
/// </summary>
public class UserClaimsContextService
{
    public UserClaimsModel Build(ClaimsPrincipal user)
    {
        return new UserClaimsModel
        {
            UserId             = int.TryParse(user.FindFirstValue("UserId"),    out var uid) ? uid : -1,
            EmpmasId           = int.TryParse(user.FindFirstValue("EmpmasId"),  out var eid) ? eid : -1,
            UserName           = user.FindFirstValue("UserName")           ?? string.Empty,
            DefCompanyId       = user.FindFirstValue("DefCompanyId")       ?? string.Empty,
            SchemaMain         = user.FindFirstValue("SchemaMain")         ?? string.Empty,
            SchemaMainPis      = user.FindFirstValue("SchemaMainPis")      ?? string.Empty,
            SchemaUserPis      = user.FindFirstValue("SchemaUserPis")      ?? string.Empty,
            SchemaUserPay      = user.FindFirstValue("SchemaUserPay")      ?? string.Empty,
            SchemaUserAms      = user.FindFirstValue("SchemaUserAms")      ?? string.Empty,
            SchemaUserAcctg    = user.FindFirstValue("SchemaUserAcctg")    ?? string.Empty,
            SchemaUserApp      = user.FindFirstValue("SchemaUserApp")      ?? string.Empty,
            CoName             = user.FindFirstValue("CoName")             ?? string.Empty,
            OempNumber         = user.FindFirstValue("OempNumber")         ?? string.Empty,
            OpisDb             = user.FindFirstValue("OpisDb")             ?? string.Empty,
            OpayDb             = user.FindFirstValue("OpayDb")             ?? string.Empty,
            Email              = user.FindFirstValue("Email")              ?? string.Empty,
            Conn               = user.FindFirstValue("Conn")               ?? string.Empty,
            ConnNoDb           = user.FindFirstValue("ConnNoDb")           ?? string.Empty,
            ConnPay            = user.FindFirstValue("ConnPay")            ?? string.Empty,
            ConnPis            = user.FindFirstValue("ConnPis")            ?? string.Empty,
            ConnAcctg          = user.FindFirstValue("ConnAcctg")          ?? string.Empty,
            IsExclusiveCompany = user.FindFirstValue("IsExclusiveCompany")
        };
    }
}

/// <summary>
/// Mirrors MBApiLibrary UserClaimsModel — passed as [Parameter] into Blazor components.
/// </summary>
public class UserClaimsModel
{
    public int?    UserId             { get; set; } = -1;
    public int?    EmpmasId           { get; set; } = -1;
    public string? UserName           { get; set; } = string.Empty;
    public string? DefCompanyId       { get; set; } = string.Empty;
    public string? SchemaMain         { get; set; } = string.Empty;
    public string? SchemaMainPis      { get; set; } = string.Empty;
    public string? SchemaUserPis      { get; set; } = string.Empty;
    public string? SchemaUserPay      { get; set; } = string.Empty;
    public string? SchemaUserAms      { get; set; } = string.Empty;
    public string? SchemaUserAcctg    { get; set; } = string.Empty;
    public string? SchemaUserApp      { get; set; } = string.Empty;
    public string? CoName             { get; set; } = string.Empty;
    public string? OempNumber         { get; set; } = string.Empty;
    public string? OpisDb             { get; set; } = string.Empty;
    public string? OpayDb             { get; set; } = string.Empty;
    public string? Email              { get; set; } = string.Empty;
    public string? Conn               { get; set; } = string.Empty;
    public string? ConnNoDb           { get; set; } = string.Empty;
    public string? ConnPay            { get; set; } = string.Empty;
    public string? ConnPis            { get; set; } = string.Empty;
    public string? ConnAcctg          { get; set; } = string.Empty;
    public string? IsExclusiveCompany { get; set; }
}
