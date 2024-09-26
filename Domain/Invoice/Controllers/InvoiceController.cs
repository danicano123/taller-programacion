using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.Invoice.Controllers;

[ApiController]
[Route("api/v1/invoice")]
public class InvoiceController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetInvoice()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneInvoice(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoice(int id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EditInvoice(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        return Ok();
    }
}