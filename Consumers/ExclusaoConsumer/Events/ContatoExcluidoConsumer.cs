using Domain.Interfaces.Services;
using Domain.Models;
using MassTransit;

namespace ExclusaoConsumer.Events;

public class ContatoExcluidoConsumer(IContatoService contatoService) : IConsumer<Contato>
{
    public async Task Consume(ConsumeContext<Contato> context)
    {
        var contatoExcluido = await contatoService.ExcluirContato(context.Message.Id);

        if (contatoExcluido.Sucesso)
            Console.WriteLine(contatoExcluido.Mensagem);
        else
            Console.WriteLine("Erro ao excluir o contato");
    }
}
