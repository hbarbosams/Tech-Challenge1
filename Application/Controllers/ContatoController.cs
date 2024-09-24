using Domain.DTOs.Saida;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.QueueRequest;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContatoController : Controller
{
    private readonly IContatoService _contatoService;
    private readonly IBus _bus;
    private readonly IConfiguration _configuration;

    public ContatoController(IContatoService contatoService, IBus bus, IConfiguration configuration)
    {
        _contatoService = contatoService;
        _bus = bus;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> CriarContato([FromBody] Contato contato)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var nomeFila = _configuration.GetSection("MassTransit")["NomeFilaCadastro"] ?? string.Empty;
                var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
                await endpoint.Send(contato);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarContato([FromBody] Contato contato)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var nomeFila = _configuration.GetSection("MassTransit")["NomeFilaAlteracao"] ?? string.Empty;
                var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
                await endpoint.Send(contato);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        return BadRequest(500);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirContato(int id)
    {
        try
        {
            var nomeFila = _configuration.GetSection("MassTransit")["NomeFilaExclusao"] ?? string.Empty;
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(new ContatoRequest { ContatoId = id });

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterContatoId(int id)
    {
        var nomeFila = _configuration.GetSection("MassTransit")["NomeFilaConsulta"] ?? string.Empty;
        var contato = await _bus.CreateRequestClient<ContatoRequest>(new Uri($"queue:{nomeFila}"))
            .GetResponse<RespostaPadrao>(new ContatoRequest { ContatoId = id });

        if (contato.Message.Sucesso)
        {
            return Ok(contato);
        }

        return StatusCode(500, contato);
    }

    [HttpGet("ddd/{ddd}")]
    public async Task<IActionResult> ListarContatosDdd(string ddd)
    {
        var listaContatos = await _contatoService.ListarContatosDdd(ddd);
        if (listaContatos.Sucesso)
        {
            return Ok(listaContatos);
        }

        return StatusCode(500, listaContatos);
    }
}