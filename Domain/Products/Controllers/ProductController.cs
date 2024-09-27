using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taller_programacion.Data;
using taller_programacion.Domain.Products.Models;

namespace taller_programacion.Domain.Products.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductsController(DBContext context) : ControllerBase
{

    // GET: api/v1/products
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await context.Products.ToListAsync();
        return Ok(products);
    }

    // GET: api/v1/products/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound(new { message = "Product not found." });
        }

        return Ok(product);
    }

    // POST: api/v1/products
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Products.Add(product);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // PATCH: api/v1/products/{id}
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
    {
        if (id != product.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingProduct = await context.Products.FindAsync(id);
        if (existingProduct == null)
        {
            return NotFound(new { message = "Product not found." });
        }

        // Update fields
        existingProduct.Code = product.Code;
        existingProduct.Name = product.Name;
        existingProduct.Stock = product.Stock;
        existingProduct.UnitValue = product.UnitValue;

        context.Entry(existingProduct).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/v1/products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound(new { message = "Product not found." });
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
