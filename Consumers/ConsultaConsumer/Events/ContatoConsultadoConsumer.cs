using Domain.QueueRequest;
using MassTransit;
using Service.Services;

namespace ConsultaConsumer.Events;

public class ContatoConsultadoConsumer(ContatoService contatoService) : IConsumer<ContatoRequest>
{
    public async Task Consume(ConsumeContext<ContatoRequest> context)
    {
        var contato = await contatoService.ObterContatoId(context.Message.ContatoId);
        await context.RespondAsync(contato);
    }
}
