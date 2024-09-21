using Domain.Interfaces.Services;
using Domain.Models;
using MassTransit;

namespace CadastroConsumer.Events;

public class ContatoCriadoConsumer(IContatoService contatoService) : IConsumer<Contato>
{
    public async Task Consume(ConsumeContext<Contato> context)
    {
        var contatoCriado = await contatoService.CriarContato(context.Message);

        if (contatoCriado.Sucesso)
            Console.WriteLine(contatoCriado.Mensagem);
        else
            Console.WriteLine("Erro ao criar o contato");
    }
}
