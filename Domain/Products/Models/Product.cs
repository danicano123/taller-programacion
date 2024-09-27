using System.ComponentModel.DataAnnotations;

namespace taller_programacion.Domain.Products.Models;

public class Product
{
    
    [Key]
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Stock { get; set; } 
    public double UnitValue { get; set; }

}