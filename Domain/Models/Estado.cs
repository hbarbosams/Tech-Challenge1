using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Estado
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do Estado é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O Nome deve ter no mínimo 2 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A sigla é obrigatória")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "A sigla deve conter duas letras")]
    public string Sigla { get; set; }
    

    [ForeignKey("RegiaoId")]
    public Regiao Regiao { get; set; }
}