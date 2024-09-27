using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taller_programacion.Data;
using taller_programacion.Domain.NormativeAspects.Models;

namespace taller_programacion.Domain.NormativeAspects.Controllers;

[ApiController]
[Route("api/v1/normative-aspects")]
public class NormativeAspectsController : ControllerBase
{
    private readonly DBContext _context;

    public NormativeAspectsController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetNormativeAspects()
    {
        var aspects = await _context.NormativeAspects.ToListAsync();
        return Ok(aspects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOneNormativeAspect(int id)
    {
        var aspect = await _context.NormativeAspects.FindAsync(id);
        if (aspect == null)
        {
            return NotFound(new { message = "Normative Aspect not found." });
        }

        return Ok(aspect);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNormativeAspect([FromBody] NormativeAspect aspect)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.NormativeAspects.Add(aspect);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOneNormativeAspect), new { id = aspect.Id }, aspect);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> EditNormativeAspect(int id, [FromBody] NormativeAspect aspect)
    {
        if (id != aspect.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingAspect = await _context.NormativeAspects.FindAsync(id);
        if (existingAspect == null)
        {
            return NotFound(new { message = "Normative Aspect not found." });
        }

        existingAspect.Type = aspect.Type;
        existingAspect.Description = aspect.Description;
        existingAspect.Source = aspect.Source;

        _context.Entry(existingAspect).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNormativeAspect(int id)
    {
        var aspect = await _context.NormativeAspects.FindAsync(id);
        if (aspect == null)
        {
            return NotFound(new { message = "Normative Aspect not found." });
        }

        _context.NormativeAspects.Remove(aspect);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
