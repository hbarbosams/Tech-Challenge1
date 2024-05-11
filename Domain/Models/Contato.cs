using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Contato
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public int FoneDddId { get; set; }
    
    [ForeignKey("FoneDddId")]
    public FoneDdd? FoneDdd { get; set; } 
}