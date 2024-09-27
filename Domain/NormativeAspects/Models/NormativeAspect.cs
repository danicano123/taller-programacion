using System.ComponentModel.DataAnnotations;

namespace taller_programacion.Domain.NormativeAspects.Models;

public class NormativeAspect
{
    [Key]
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;

}
