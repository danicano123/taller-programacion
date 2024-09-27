using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taller_programacion.Data;
using taller_programacion.Domain.Invoices.Models;

namespace taller_programacion.Domain.Invoices.Controllers;

[ApiController]
[Route("api/v1/invoices")]
public class InvoicesController : ControllerBase
{
    private readonly DBContext _context;

    public InvoicesController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetInvoices()
    {
        var invoices = await _context.Invoices.ToListAsync();
        return Ok(invoices);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvoice(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        if (invoice == null)
        {
            return NotFound(new { message = "Invoice not found." });
        }

        return Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateInvoice(int id, [FromBody] Invoice invoice)
    {
        if (id != invoice.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingInvoice = await _context.Invoices.FindAsync(id);
        if (existingInvoice == null)
        {
            return NotFound(new { message = "Invoice not found." });
        }

        existingInvoice.Date = invoice.Date;
        existingInvoice.Number = invoice.Number;
        existingInvoice.Total = invoice.Total;

        _context.Entry(existingInvoice).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        if (invoice == null)
        {
            return NotFound(new { message = "Invoice not found." });
        }

        _context.Invoices.Remove(invoice);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
