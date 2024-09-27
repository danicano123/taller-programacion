using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taller_programacion.Data;
using taller_programacion.Domain.Sellers.Models;

namespace taller_programacion.Domain.Sellers.Controllers;

[ApiController]
[Route("api/v1/sellers")]
public class SellersController : ControllerBase
{
    private readonly DBContext _context;

    public SellersController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetSellers()
    {
        var sellers = await _context.Sellers.ToListAsync();
        return Ok(sellers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSeller(int id)
    {
        var seller = await _context.Sellers.FindAsync(id);
        if (seller == null)
        {
            return NotFound(new { message = "Seller not found." });
        }

        return Ok(seller);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSeller([FromBody] Seller seller)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Sellers.Add(seller);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSeller), new { id = seller.Id }, seller);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateSeller(int id, [FromBody] Seller seller)
    {
        if (id != seller.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingSeller = await _context.Sellers.FindAsync(id);
        if (existingSeller == null)
        {
            return NotFound(new { message = "Seller not found." });
        }

        existingSeller.License = seller.License;
        existingSeller.Direcction = seller.Direcction;

        _context.Entry(existingSeller).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSeller(int id)
    {
        var seller = await _context.Sellers.FindAsync(id);
        if (seller == null)
        {
            return NotFound(new { message = "Seller not found." });
        }

        _context.Sellers.Remove(seller);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
