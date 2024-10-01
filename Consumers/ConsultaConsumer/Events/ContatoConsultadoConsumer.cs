using Domain.Interfaces.Services;
using Domain.QueueRequest;
using MassTransit;

namespace ConsultaConsumer.Events;

public class ContatoConsultadoConsumer(IContatoService contatoService) : IConsumer<ContatoRequest>
{
    public async Task Consume(ConsumeContext<ContatoRequest> context)
    {
        var contato = await contatoService.ObterContatoId(context.Message.ContatoId);
        await context.RespondAsync(contato);
    }
}
