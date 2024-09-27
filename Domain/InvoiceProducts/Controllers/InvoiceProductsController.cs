using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taller_programacion.Data;
using taller_programacion.Domain.InvoiceProducts.Models;

namespace taller_programacion.Domain.InvoiceProducts.Controllers
{
    [ApiController]
    [Route("api/v1/invoice-products")]
    public class InvoiceProductsController : ControllerBase
    {
        private readonly DBContext _context;

        public InvoiceProductsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoiceProducts()
        {
            var invoiceProducts = await _context.InvoiceProducts.ToListAsync();
            return Ok(invoiceProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceProduct(int id)
        {
            var invoiceProduct = await _context.InvoiceProducts.FindAsync(id);
            if (invoiceProduct == null)
            {
                return NotFound(new { message = "InvoiceProduct not found." });
            }

            return Ok(invoiceProduct);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoiceProduct([FromBody] InvoiceProduct invoiceProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InvoiceProducts.Add(invoiceProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvoiceProduct), new { id = invoiceProduct.Id }, invoiceProduct);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditInvoiceProduct(int id, [FromBody] InvoiceProduct invoiceProduct)
        {
            if (id != invoiceProduct.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }

            var existingInvoiceProduct = await _context.InvoiceProducts.FindAsync(id);
            if (existingInvoiceProduct == null)
            {
                return NotFound(new { message = "InvoiceProduct not found." });
            }

            existingInvoiceProduct.Quantity = invoiceProduct.Quantity;
            existingInvoiceProduct.Subtotal = invoiceProduct.Subtotal;

            _context.Entry(existingInvoiceProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceProduct(int id)
        {
            var invoiceProduct = await _context.InvoiceProducts.FindAsync(id);
            if (invoiceProduct == null)
            {
                return NotFound(new { message = "InvoiceProduct not found." });
            }

            _context.InvoiceProducts.Remove(invoiceProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
