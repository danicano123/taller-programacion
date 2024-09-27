using System.ComponentModel.DataAnnotations;
using taller_programacion.Domain.Common.Models;

namespace taller_programacion.Domain.Sellers.Models;

public class Seller: Person
{

    public int License { get; set; }
    public string Direcction { get; set; } = string.Empty;
}