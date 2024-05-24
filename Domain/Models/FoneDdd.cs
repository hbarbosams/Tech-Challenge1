using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class FoneDdd
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O DDD é obrigatório")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "O DDD deve conter dois números")]
    public string Ddd { get; set; }
    
    [ForeignKey("EstadoId")]
    public Estado Estado { get; set; }
}