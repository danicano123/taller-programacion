using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taller_programacion.Data;
using taller_programacion.Domain.Clients.Models;

namespace taller_programacion.Domain.Clients.Controllers;

[ApiController]
[Route("api/v1/clients")]
public class ClientsController(DBContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetClients()
    {
        var clients = await context.Clients.ToListAsync();
        return Ok(clients);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClient(int id)
    {
        var client = await context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound(new { message = "Client not found." });
        }

        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] Client client)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Clients.Add(client);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateClient(int id, [FromBody] Client client)
    {
        if (id != client.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingClient = await context.Clients.FindAsync(id);
        if (existingClient == null)
        {
            return NotFound(new { message = "Client not found." });
        }

        existingClient.Credit = client.Credit;

        context.Entry(existingClient).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound(new { message = "Client not found." });
        }

        context.Clients.Remove(client);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
