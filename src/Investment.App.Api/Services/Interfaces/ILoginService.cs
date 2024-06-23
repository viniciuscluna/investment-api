using Investment.App.Api.Models;

namespace Investment.App.Api.Services;

public interface ILoginService
{
    Login Authenticate(string userName, string password);
}
