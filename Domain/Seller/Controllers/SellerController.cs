using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.Seller.Controllers;

[ApiController]
[Route("api/v1/seller")]
public class SellerController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetSeller()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneSeller(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSeller(int id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EditSeller(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteSeller(int id)
    {
        return Ok();
    }
}