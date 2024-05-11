using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IContatoRepository
{
    Task<Contato> InserirContato(Contato contato);
    Task<List<Contato>> ListarContatosDdd(string ddd);
    Task<Contato?> ObterContatoId(int id);
    Task<Contato> AtualizarContato(Contato contato);
    Task<bool> ExcluirContato(int id);
}