using System.ComponentModel.DataAnnotations;
using taller_programacion.Domain.Common.Models;

namespace taller_programacion.Domain.Clients.Models;

public class Client: Person
{
    public double Credit { get; set; } 

}