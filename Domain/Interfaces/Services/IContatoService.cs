using Domain.DTOs.Saida;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IContatoService
{
    Task<RespostaPadrao> CriarContato(Contato contato);
    Task<RespostaPadrao> ListarContatosDdd(string ddd);
    Task<RespostaPadrao> ObterContatoId(int id);
    Task<RespostaPadrao> AtualizarContato(Contato contato);
    Task<RespostaPadrao> ExcluirContato(int id);
}