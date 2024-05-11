using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Estado
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
    
    [ForeignKey("RegiaoId")]
    public Regiao Regiao { get; set; }
}