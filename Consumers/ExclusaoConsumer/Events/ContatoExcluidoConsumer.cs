using Domain.Interfaces.Services;
using Domain.Models;
using Domain.QueueRequest;
using MassTransit;
using Service.Services;

namespace ExclusaoConsumer.Events;

public class ContatoExcluidoConsumer(IContatoService contatoService) : IConsumer<ContatoRequest>
{
    public async Task Consume(ConsumeContext<ContatoRequest> context)
    {
        var contatoExcluido = await contatoService.ExcluirContato(context.Message.ContatoId);

        if (contatoExcluido.Sucesso)
            Console.WriteLine(contatoExcluido.Mensagem);
        else
            Console.WriteLine("Erro ao excluir o contato");
    }
}
