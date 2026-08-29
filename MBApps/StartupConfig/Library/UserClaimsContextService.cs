using System.Security.Claims;
using MBApiLibrary.Models._00_Main;

namespace MBApps.StartupConfig.Library;


public class UserClaimsContextService
{
    public UserClaimsModel Build(ClaimsPrincipal user)
    {
        return new UserClaimsModel
        {
            UserId             = int.TryParse(user.FindFirstValue("UserId"),    out var uid) ? uid : 0,
            EmpmasId           = int.TryParse(user.FindFirstValue("EmpmasId"),  out var eid) ? eid : 0,
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


