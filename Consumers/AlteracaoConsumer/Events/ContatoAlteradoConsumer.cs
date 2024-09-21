using Domain.Interfaces.Services;
using Domain.Models;
using MassTransit;

namespace AlteracaoConsumer.Events;

public class ContatoAlteradoConsumer(IContatoService contatoService) : IConsumer<Contato>
{
    public async Task Consume(ConsumeContext<Contato> context)
    {
        var contatoAtualizado = await contatoService.AtualizarContato(context.Message);

        if (contatoAtualizado.Sucesso)
            Console.WriteLine(contatoAtualizado.Mensagem);
        else
            Console.WriteLine("Erro ao alterar o contato");
    }
}
