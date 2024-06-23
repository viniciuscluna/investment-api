namespace Investment.App.Api.ViewModels.Login;

public class LoginResponseViewModel
{
        public string? Token { get; set; }
        public DateTime ExpiresIn { get; set; }
}
