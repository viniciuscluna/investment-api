using Investment.App.Api.Services;
using Investment.App.Api.ViewModels.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Investment.App.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "User")]
public class UserController(IFinancialProductService _financialProductService, IOperationService _operationService) : ControllerBase
{
    [HttpGet("products")]
    public async Task<IActionResult> GetProducts(){
        return Ok(await _financialProductService.GetAllAsync());
    }

    [HttpPost("buy")]
    public async Task<IActionResult> Buy(BuyRequestViewModel request){
        var result = await _operationService.BuyAsync(request);
        if(result.IsValid) return Created();
        else return BadRequest(result);
    }

    [HttpPost("sell")]
    public async Task<IActionResult> Sell(SellRequestViewModel request){
        var result = await _operationService.SellAsync(request);
        if(result.IsValid) return Created();
        else return BadRequest(result);
    }

}
