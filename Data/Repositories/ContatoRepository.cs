using Data.Context;
using Data.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly TechChallengeContext _context;
    public ContatoRepository(TechChallengeContext context)
    {
        _context = context;
    }

    public async Task<Contato> InserirContato(Contato contato)
    {
        try
        {
            await _context.Contato.AddAsync(contato);
            await _context.SaveChangesAsync();
            return contato;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao adicionar novo contato", ex);
        }
    }

    public async Task<List<Contato>> ListarContatosDdd(string ddd)
    {
        try
        {
            var contatosDdd = await _context.Contato
                .Include(i => i.FoneDdd)
                .ThenInclude(i => i.Estado)
                .ThenInclude(i => i.Regiao)
                .Where(w => w.FoneDdd.Ddd == ddd)
                .AsNoTracking()
                .ToListAsync();
            
            return contatosDdd;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao obter contatos por DDD", ex);
        }
    }

    public async Task<Contato> AtualizarContato(Contato contato)
    {
        try
        {
            _context.Contato.Update(contato);
            await _context.SaveChangesAsync();
            return contato;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao atualizar contato", ex);
        }
    }

    public async Task<bool> ExcluirContato(int id)
    {
        try
        {
            var contato = await _context.Contato.SingleOrDefaultAsync(s => s.Id == id);
            if (contato == null)
            {
                return false;
            }

            _context.Contato.Remove(contato);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao excluir contato", ex);
        }
    }
}