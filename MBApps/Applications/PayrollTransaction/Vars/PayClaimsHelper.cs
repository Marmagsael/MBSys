using System.Security.Claims;
using MBApiLibrary.Models._00_Main;

namespace MBApps.Applications.PayrollTransaction.Vars;

public static class PayClaimsHelper
{
    public static UserClaimsModel UserToClaims(ClaimsPrincipal user)
    {
        return new UserClaimsModel
        {
            UserId = int.TryParse(user.FindFirst("UserId")?.Value, out var userId) ? userId : -1,
            EmpmasId = int.TryParse(user.FindFirst("EmpmasId")?.Value,out var empmasId) ? empmasId : -1,
            UserName = user.FindFirst("UserName")?.Value ?? string.Empty,
            Email = user.FindFirst("Email")?.Value ?? string.Empty,
            DefCompanyId = user.FindFirst("DefCompanyId")?.Value ?? string.Empty,
            SchemaMain = user.FindFirst("SchemaMain")?.Value ?? string.Empty,
            SchemaMainPis = user.FindFirst("SchemaMainPis")?.Value ?? string.Empty,
            SchemaUserPis = user.FindFirst("SchemaUserPis")?.Value ?? string.Empty,
            SchemaUserPay = user.FindFirst("SchemaUserPay")?.Value ?? string.Empty,
            SchemaUserAms = user.FindFirst("SchemaUserAms")?.Value ?? string.Empty,
            SchemaUserAcctg = user.FindFirst("SchemaUserAcctg")?.Value ?? string.Empty,
            SchemaUserApp = user.FindFirst("SchemaUserApp")?.Value ?? string.Empty,
            CoName = user.FindFirst("CoName")?.Value ?? string.Empty,
            OempNumber = user.FindFirst("OempNumber")?.Value ?? string.Empty,
            OpisDb = user.FindFirst("OpisDb")?.Value ?? string.Empty,
            OpayDb = user.FindFirst("OpayDb")?.Value ?? string.Empty,
            Conn = user.FindFirst("Conn")?.Value ?? string.Empty,
            ConnNoDb = user.FindFirst("ConnNoDb")?.Value ?? string.Empty,
            ConnPay = user.FindFirst("ConnPay")?.Value ?? string.Empty,
            ConnPis = user.FindFirst("ConnPis")?.Value ?? string.Empty,
            ConnAcctg = user.FindFirst("ConnAcctg")?.Value ?? string.Empty,
            IsExclusiveCompany  = user.FindFirst("IsExclusiveCompany")?.Value ?? string.Empty
        };
    }
}