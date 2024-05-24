using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Regiao
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da regi�o � obrigat�rio")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome da regi�o deve ter no m�nimo duas letras")]
    public string Nome { get; set; }
}