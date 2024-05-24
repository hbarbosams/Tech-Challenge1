using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Contato
{
    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "O campo Nome � obrigat�rio")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O Nome deve ter no m�nimo 2 caracteres")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "O campo E-mail � obrigat�rio")]
    [EmailAddress(ErrorMessage = "E-mail inv�lido")]
    public string Email { get; set; }


    [Required(ErrorMessage = "O telefone � obrigat�rio")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "O n�mero de telefone deve ter 9 d�gitos")]
    public string Telefone { get; set; }


    [Required(ErrorMessage = "O ID do telefone � obrigat�rio")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "O ID do telefone deve ter 2 caracteres")]
    public int FoneDddId { get; set; }


    [ForeignKey("FoneDddId")]
    public FoneDdd? FoneDdd { get; set; } 
}