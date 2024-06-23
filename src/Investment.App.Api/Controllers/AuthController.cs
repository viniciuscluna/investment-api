using Investment.App.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investment.App.Api;

[Route("api/[controller]")]
public class AuthController(ILoginService _loginService) : ControllerBase {
    
    [HttpPost]
    public IActionResult Login(LoginViewModel vm){
        return Ok(_loginService.Authenticate(vm.Login, vm.Password));
    }
}