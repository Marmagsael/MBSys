using MBApiLibrary.DataAccess._00_Login;
using MBApiLibrary.DataAccess._00_Login.Interface;
using MBApiLibrary.Models._00_Main;
using MBApiLibrary.Models._90_Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MBApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly I_00_001_LoginAccess _loginAccess;
    private readonly IConfiguration       _config;

    public AuthController(I_00_001_LoginAccess loginAccess, IConfiguration config)
    {
        _loginAccess = loginAccess;
        _config      = config;
    }

    // POST api/auth/login
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginInputModel input)
    {
        string schema = _config.GetSection("Schema:Main").Value ?? "Main";

        // 1). Validate credentials
        UsersModel? user = await _loginAccess._011_LoginByLoginName_Main(input.LoginName, input.Password, schema);

        if (user is null)
            return Unauthorized(new { Message = "Invalid username or password." });

        if (user.Status != "A")
            return Unauthorized(new { Message = "Account is inactive." });

        // 2). Generate JWT token
        string token = await _loginAccess.CreateToken(user.Id, user.LoginName, schema);

        // 3). Return user + token
        return Ok(new
        {
            user.Id,
            user.LoginName,
            user.Email,
            user.Domain,
            user.UserType,
            user.Status,
            user.DefaultCoId,
            user.OldPis,
            user.OldPay,
            user.Empnumber,
            Token = token
        });
    }
}

