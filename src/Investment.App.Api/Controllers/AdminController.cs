using Investment.App.Api.Services;
using Investment.App.Api.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Investment.App.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class AdminController(IFinancialProductService _service) : ControllerBase
{
    [HttpGet("products")]
    public async Task<IActionResult> GetProducts(){
        var products = await _service.GetAllAsync();
        return Ok(products);
    }

    [HttpPut("product/{productId}")]
    public async Task<IActionResult> PutProduct(Guid productId, UpdateProductViewModel request){
        await _service.UpdateAsync(productId, request);
        return Created();
    }
}
