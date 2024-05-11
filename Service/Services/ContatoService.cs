using Domain.DTOs.Saida;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Service.Services;

public class ContatoService : IContatoService
{
    private readonly IContatoRepository _contatoRepository;
    public ContatoService(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    public async Task<RespostaPadrao> CriarContato(Contato contato)
    {
        try
        {
            var novoContato = await _contatoRepository.InserirContato(contato);
            return new RespostaPadrao(true, novoContato, "Contato criado com sucesso");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> ListarContatosDdd(string ddd)
    {
        try
        {
            var listaContatos = await _contatoRepository.ListarContatosDdd(ddd);
            return new RespostaPadrao(true, listaContatos, null);
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> ObterContatoId(int id)
    {
        try
        {
            var contato = await _contatoRepository.ObterContatoId(id);
            if (contato != null)
            {
                return new RespostaPadrao(true, contato, null);
            }

            return new RespostaPadrao(true, null, "Contato não encontrado");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> AtualizarContato(Contato contato)
    {
        try
        {
            var contatoAtualizado = await _contatoRepository.AtualizarContato(contato);
            return new RespostaPadrao(true, contatoAtualizado, "Contato atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }

    public async Task<RespostaPadrao> ExcluirContato(int id)
    {
        try
        {
            var contatoExcluido = await _contatoRepository.ExcluirContato(id);
            return new RespostaPadrao(true, contatoExcluido, "Contato excluido com sucesso");
        }
        catch (Exception ex)
        {
            return new RespostaPadrao(false, null, ex.Message);
        }
    }
}