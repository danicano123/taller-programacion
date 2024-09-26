using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.Product.Controllers;

[ApiController]
[Route("api/v1/prodcut")]
public class ProductController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneProduct(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(int id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EditProduct(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProducts(int id)
    {
        return Ok();
    }
}