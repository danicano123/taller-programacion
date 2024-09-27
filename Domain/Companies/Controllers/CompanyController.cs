using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taller_programacion.Data;
using taller_programacion.Domain.Companies.Models;

namespace taller_programacion.Domain.Companies.Controllers;

[ApiController]
[Route("api/v1/companies")]
public class CompaniesController : ControllerBase
{
    private readonly DBContext _context;

    public CompaniesController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _context.Companies.ToListAsync();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company == null)
        {
            return NotFound(new { message = "Company not found." });
        }

        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] Company company)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCompany(int id, [FromBody] Company company)
    {
        if (id != company.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingCompany = await _context.Companies.FindAsync(id);
        if (existingCompany == null)
        {
            return NotFound(new { message = "Company not found." });
        }

        existingCompany.Code = company.Code;
        existingCompany.Name = company.Name;

        _context.Entry(existingCompany).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company == null)
        {
            return NotFound(new { message = "Company not found." });
        }

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
