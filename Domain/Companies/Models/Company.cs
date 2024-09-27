using System.ComponentModel.DataAnnotations;

namespace taller_programacion.Domain.Companies.Models;

public class Company
{
    [Key]
    public int Id { get; set; }
    public int Code { get; set; }
    public string Name { get; set; } = string.Empty;
}