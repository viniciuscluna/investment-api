using Investment.App.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Investment.App.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "User")]
public class UserController(IFinancialProductService _service) : ControllerBase
{
    [HttpGet("products")]
    public async Task<IActionResult> GetProducts(){
        return Ok(await _service.GetAllAsync());
    }


    //[HttpPost("invest")]

}
