namespace Domain.DTOs.Saida;

public class RespostaPadrao
{
    public RespostaPadrao(bool sucesso, object? resposta, string? mensagem)
    {
        Sucesso = sucesso;
        Resposta = resposta;
        Mensagem = mensagem;
    }
    
    public bool Sucesso { get; set; }
    public object? Resposta { get; set; }
    public string? Mensagem { get; set; }
}