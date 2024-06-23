using AutoMapper;
using Investment.App.Api.Services;
using Investment.App.Api.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;

namespace Investment.App.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(ILoginService _loginService, IMapper _mapper) : ControllerBase {
    
    [HttpPost]
    public IActionResult Login(LoginRequestViewModel vm){
        var result = _loginService.Authenticate(vm.Login, vm.Password);

        if(result.IsValid) return Ok(_mapper.Map<LoginResponseViewModel>(result));
        else return StatusCode(500);
    }
}