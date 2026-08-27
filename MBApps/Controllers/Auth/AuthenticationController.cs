using MBApiLibrary.DataAccess._00_Main;
using MBApiLibrary.DataAccess._00_Main.Interface;
using MBApiLibrary.DataAccess._20_Pay.Interface;
using MBApiLibrary.DataAccess._90_Utils.Interface;
using MBApiLibrary.Models._00_Main;
using MBApiLibrary.Models._00_MainPis;
using MBApps.Models.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Security.Claims;

namespace MBApps.Controllers.Auth;

public class AuthenticationController : Controller
{
    private readonly IConfiguration _config;
    private readonly I_00UsersAccess _userAccess;
    private readonly I_90_001_MySqlDataAccess _mysql;
    private readonly I_00MainDA _mainDA;
    private readonly I_00MainPisAccess _mainPis;
    private readonly I_00MainPisTblMakerAccess _mainPisTblMaker;
    private readonly I_20_002_PayTblMaker _payTblMaker;
    private readonly I_00UserscompanyDataAccess _userCompany;
    private readonly I_AcctgTableMaker _acctg;

    public AuthenticationController(
        IConfiguration config,
        I_00UsersAccess userAccess,
        I_90_001_MySqlDataAccess mysql,
        I_00MainDA mainDA,
        I_00MainPisAccess mainPis,
        I_00MainPisTblMakerAccess mainPisTblMaker,
        I_20_002_PayTblMaker payTblMaker,
        I_00UserscompanyDataAccess userCompany,
        I_AcctgTableMaker acctg)
    {
        _config = config;
        _userAccess = userAccess;
        _mysql = mysql;
        _mainDA = mainDA;
        _mainPis = mainPis;
        _mainPisTblMaker = mainPisTblMaker;
        _payTblMaker = payTblMaker;
        _userCompany = userCompany;
        _acctg = acctg;
    }


    // ==================================================================================
    // GET
    // ==================================================================================

    [AllowAnonymous]
    [HttpGet("login")]
    public IActionResult Login()
    {
        LoadLoginViewData();
        return View();
    }

    [AllowAnonymous]
    [HttpGet("register")]
    public IActionResult Register()
    {
        LoadLoginViewData();
        return View();
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }


    // ==================================================================================
    // POST — Login
    // ==================================================================================

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginPost(LoginUiModel input)
    {
        LoadLoginViewData();
        ViewData["ErrorMsg"] = string.Empty;

        if (!ModelState.IsValid)
        {
            ViewData["ErrorMsg"] = "Please fill in all required fields.";
            return View("Login", input);
        }

        try
        {
            var conn = _config.GetSection("Schema:DefConn").Value ?? "MySqlConn";
            var schema = _config.GetSection("Schema:Main").Value ?? "Main";
            var isExclusive = _config.GetSection("CompanyInfo:Exclusive").Value ?? "false";

            // 1). Validate credentials
            UsersModel? user = await _mainDA._02UsersLoginLoginName(input.LoginName, input.Password, schema, conn);

            if (user is null)
            {
                ViewData["ErrorMsg"] = "Invalid username or password.";
                return View("Login", input);
            }

            // 2). Get User Company
            UserCompanyModel? uc = await _GetUserCompany(user, schema, conn);

            // 3). Create schema/tables if needed
            _CreateSchemaAndTables(uc?.PisSchema, conn);

            // 4). Build claims & sign in
            await CreateClaims(user, uc);

            // 5). Create company-level tables
            await CreateCompany(user, uc, conn);

            return RedirectToAction("Index", "Home");
        }
        catch (MySqlException)
        {
            ViewData["ErrorMsg"] = "Cannot reach the server. Please try again shortly.";
            return View("Login", input);
        }
        catch (Exception)
        {
            ViewData["ErrorMsg"] = "Something went wrong. Please try again.";
            return View("Login", input);
        }
    }


    // ==================================================================================
    // POST — Register (simple user creation, no company)
    // ==================================================================================

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterPost(RegisterUiModel input)
    {
        LoadLoginViewData();
        ViewData["ErrorMsg"] = string.Empty;

        if (!ModelState.IsValid)
        {
            ViewData["ErrorMsg"] = "Please fill in all required fields.";
            return View("Register", input);
        }

        var conn = _config.GetSection("Schema:DefConn").Value ?? "MySqlConn";
        var schema = _config.GetSection("Schema:Main").Value ?? "Main";

        // Check duplicate username
        var existingUser = await _userAccess._02ByLoginName(input.LoginName, schema, conn);
        if (existingUser != null)
        {
            ViewData["ErrorMsg"] = "Username already exists.";
            return View("Register", input);
        }

        // Check duplicate email
        var existingEmail = await _userAccess._02ByEmail(input.Email, schema, conn);
        if (existingEmail != null)
        {
            ViewData["ErrorMsg"] = "Email already exists.";
            return View("Register", input);
        }

        // Create user
        var domain = _config.GetSection("Schema:Domain").Value ?? string.Empty;
        UsersModel newUser = new()
        {
            LoginName = input.LoginName,
            Password = input.Password,
            Email = input.Email,
            Domain = domain,
            UserType = 1,
            Status = "A",
            DefaultCoId = 0
        };

        UsersModel? created = await _userAccess._01(newUser, schema, conn);
        if (created is null)
        {
            ViewData["ErrorMsg"] = "Error creating user. Please try again.";
            return View("Register", input);
        }

        // Create MainPis.Empmas record
        var mainPisSchema = _config.GetSection("Schema:MainPis").Value ?? "MainPis";
        EmpmasModel empmas = new()
        {
            Id = created.Id,
            EmpLastNm = input.EmpLastNm,
            EmpFirstNm = input.EmpFirstNm,
            EmpMidNm = input.EmpMidNm,
            Suffix = input.Suffix,
            EmpAlias = input.EmpAlias
        };
        await _mainPis._01Empmas(empmas, mainPisSchema, conn);

        // Sign in directly after register
        UserCompanyModel? uc = await _GetUserCompany(created, schema, conn);
        await CreateClaims(created, uc);

        return RedirectToAction("Index", "Home");
    }


    // ==================================================================================
    // Change Company (switch active company)
    // ==================================================================================

    [HttpGet("changingclaims/{userCompanyId}")]
    public async Task<IActionResult> ChangeCompany(int userCompanyId)
    {
        var conn = _config.GetSection("Schema:DefConn").Value ?? "MySqlConn";
        var schema = _config.GetSection("Schema:Main").Value ?? "Main";

        var userIdStr = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        if (!int.TryParse(userIdStr, out int userId))
            return RedirectToAction("Login");

        UsersModel? user = await _mainDA._02UsersById(userId, schema, conn);
        if (user is null) return RedirectToAction("Login");

        user.DefaultCoId = userCompanyId;
        await _mainDA._03Users(userCompanyId, user, schema, conn);

        UserCompanyModel? uc = await _GetUserCompany(user, schema, conn);
        _CreateSchemaAndTables(uc?.PisSchema, conn);
        await CreateClaims(user, uc);
        await CreateCompany(user, uc, conn);

        return RedirectToAction("Index", "Home");
    }


    // ==================================================================================
    // Claims Builder
    // ==================================================================================

    public async Task CreateClaims(UsersModel user, UserCompanyModel? uc)
    {
        var userId = user.Id.ToString() ?? "0";
        var defCoId = user.DefaultCoId.ToString() ?? "0";

        var prefix = $"U{userId}C{uc?.Id ?? 1}";
        var pisSchema = uc?.PisSchema ?? prefix + "Pis";
        var paySchema = uc?.PaySchema ?? prefix + "Pay";
        var acctgSchema = prefix + "Acctg";
        var appSchema = uc?.ApplicantSchema ?? prefix + "App";
        var amsSchema = uc?.AmsSchema ?? prefix + "Ams";
        var coName = uc?.CompanyName ?? string.Empty;

        var schemaMain = _config.GetSection("Schema:Main").Value ?? "Main";
        var schemaMainPis = _config.GetSection("Schema:MainPis").Value ?? "MainPis";
        var isExclusive = _config.GetSection("CompanyInfo:Exclusive").Value ?? "false";
        var conn = user.Domain ?? "MySqlConn";

        await HttpContext.SignOutAsync();

        var claims = new List<Claim>
        {
            new("UserId",             userId),
            new("EmpmasId",           "0"),
            new("UserName",           user.LoginName  ?? string.Empty),
            new("Email",              user.Email      ?? string.Empty),
            new("DefCompanyId",       defCoId),
            new("SchemaMain",         schemaMain),
            new("SchemaMainPis",      schemaMainPis),
            new("SchemaUserPis",      pisSchema),
            new("SchemaUserPay",      paySchema),
            new("SchemaUserAms",      amsSchema),
            new("SchemaUserAcctg",    acctgSchema),
            new("SchemaUserApp",      appSchema),
            new("CoName",             coName),
            new("OempNumber",         user.Empnumber  ?? string.Empty),
            new("OpisDb",             user.OldPis     ?? string.Empty),
            new("OpayDb",             user.OldPay     ?? string.Empty),
            new("Conn",               conn),
            new("ConnNoDb",           "MySqlConnNoDb"),
            new("ConnPay",            conn),
            new("ConnPis",            conn),
            new("ConnAcctg",          conn),
            new("IsExclusiveCompany", isExclusive)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
        await HttpContext.SignInAsync(claimPrincipal);
    }


    // ==================================================================================
    // Private Helpers
    // ==================================================================================

    private void LoadLoginViewData()
    {
        ViewData["CoName"] = _config.GetSection("CompanyInfo:CompanyName").Value;
        ViewData["Exclusive"] = _config.GetSection("CompanyInfo:Exclusive").Value;
    }

    private async Task<UserCompanyModel?> _GetUserCompany(UsersModel user, string schema, string conn)
    {
        var isExclusive = _config.GetSection("CompanyInfo:Exclusive").Value ?? "false";
        UserCompanyModel? uc;

        if (isExclusive == "true")
        {
            var defaultCoId = _config.GetSection("CompanyInfo:DefaultCoId").Value ?? "1";
            uc = await _mainDA._02UserCompany(int.Parse(defaultCoId), schema, conn);
        }
        else if (user.DefaultCoId == 0)
        {
            var list = await _mainDA._02UserCompanyPerOwnerId(user.Id, schema, conn);
            uc = list.FirstOrDefault();
        }
        else
        {
            uc = await _mainDA._02UserCompany(user.DefaultCoId, schema, conn);
        }

        return uc;
    }

    private void _CreateSchemaAndTables(string? pisSchema, string conn)
    {
        if (!string.IsNullOrEmpty(pisSchema) && pisSchema != "Default")
        {
            _mainPisTblMaker._01MainPisTableInternal(pisSchema, conn);
            _mainPisTblMaker._01MainPisTable(pisSchema, conn);
        }
    }

    private async Task CreateCompany(UsersModel user, UserCompanyModel? uc, string conn)
    {
        var userId = user.Id?.ToString().Trim() ?? "0";
        var coId = user.DefaultCoId ?? 0;
        var userDb = "U" + userId;

        await _mainPisTblMaker._01UserTable(userDb, conn);

        if (coId > 1)
        {
            var prefix = userDb + "C" + coId;
            var pisDb = prefix + "Pis";
            var payDb = prefix + "Pay";
            var acctgDb = prefix + "Acctg";

            await _mainPisTblMaker._01MainPisTableInternal(pisDb, conn);
            await _payTblMaker._01(payDb);

            var userCo = await _userCompany._02(coId, "Main", conn);
            if (userCo?.CountryId == 2)
                await _payTblMaker._01PH(payDb);

            await _acctg.AccountingTableMaker(acctgDb, conn);
        }
    }
}