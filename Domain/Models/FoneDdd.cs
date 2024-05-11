using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class FoneDdd
{
    public int Id { get; set; }
    public string Ddd { get; set; }
    
    [ForeignKey("EstadoId")]
    public Estado Estado { get; set; }
}