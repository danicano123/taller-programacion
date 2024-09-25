using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.NormativeAspects.Controllers;

[ApiController]
[Route("api/v1/normative-aspects")]
public class NormativeAspectsController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetNormativeAspects()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneNormativeAspects(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateNormativeAspect(int id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EditNormativeApect(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteNormativeAspects(int id)
    {
        return Ok();
    }
}