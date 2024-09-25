using Microsoft.AspNetCore.Mvc;

namespace programming_work_backend.Domain.Client.Controllers;

[ApiController]
[Route("api/v1/client")]
public class ClientController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetClient()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneClient(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreatClient(int id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EdClient(int id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        return Ok();
    }
}