using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.Company.Controllers;

[ApiController]
[Route("api/v1/company")]
public class CompanyController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetCompany()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneCompany(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany(int id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EditCompany(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        return Ok();
    }
}