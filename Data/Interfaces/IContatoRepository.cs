using Domain.Models;

namespace Data.Interfaces;

public interface IContatoRepository
{
    Task<Contato> InserirContato(Contato contato);
    Task<List<Contato>> ListarContatosDdd(string ddd);
    Task<Contato> AtualizarContato(Contato contato);
    Task<bool> ExcluirContato(int id);
}