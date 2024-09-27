using System.ComponentModel.DataAnnotations;

namespace taller_programacion.Domain.Invoices.Models;

public class Invoice
{
    [Key]
    public int Id { get; set; }
    public string Date { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Total { get; set; } = string.Empty;

}