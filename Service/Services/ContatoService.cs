using Data.Interfaces;

namespace Service.Services;

public class ContatoService
{
    public readonly IContatoRepository _contatoRepository;
    public ContatoService(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }
}