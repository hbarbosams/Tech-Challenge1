using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Contato
{
    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O Nome deve ter no mínimo 2 caracteres")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "O campo E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }


    [Required(ErrorMessage = "O telefone é obrigatório")]
    [StringLength(10, MinimumLength = 8, ErrorMessage = "O número de telefone deve ter entre 8 e 10 dígitos")]
    public string Telefone { get; set; }


    [Required(ErrorMessage = "O ID do telefone é obrigatório")]
    public int FoneDddId { get; set; }


    [ForeignKey("FoneDddId")]
    public FoneDdd? FoneDdd { get; set; } 
}