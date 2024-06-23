namespace Investment.App.Api.Models;

public class Login
{
    public bool IsValid { get; set; }
    public string? Token { get; set; }
    public DateTime ExpiresIn { get; set; }
}
