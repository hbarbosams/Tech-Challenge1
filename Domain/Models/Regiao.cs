using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Regiao
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
}