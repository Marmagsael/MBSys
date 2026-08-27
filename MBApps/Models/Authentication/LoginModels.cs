using System.ComponentModel.DataAnnotations;

namespace MBApps.Models.Authentication;

// --- Login form input ---
public class LoginUiModel
{
    [Required] public string? LoginName { get; set; }
    [Required] public string? Password { get; set; }
}

// --- Register form input ---
public class RegisterUiModel
{
    [Required] public string? LoginName { get; set; }
    [Required] public string? Password { get; set; }
    [Required] public string? Email { get; set; }

    // Personal info for Empmas record
    public string? EmpLastNm { get; set; }
    public string? EmpFirstNm { get; set; }
    public string? EmpMidNm { get; set; }
    public string? Suffix { get; set; }
    public string? EmpAlias { get; set; }
}

// --- Response from API (kept for reference, no longer used directly) ---
public class LoginResponseModel
{
    public int Id { get; set; }
    public string? LoginName { get; set; }
    public string? Email { get; set; }
    public string? Domain { get; set; }
    public int UserType { get; set; }
    public string? Status { get; set; }
    public int DefaultCoId { get; set; }
    public string? OldPis { get; set; }
    public string? OldPay { get; set; }
    public string? Empnumber { get; set; }
    public string? Token { get; set; }
}