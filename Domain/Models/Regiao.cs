using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Regiao
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da região é obrigatório")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome da região deve ter no mínimo duas letras")]
    public string Nome { get; set; }
}