using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContatoController : Controller
{
    private readonly IContatoService _contatoService;
    public ContatoController(IContatoService contatoService)
    {
        _contatoService = contatoService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarContato([FromBody] Contato contato)
    {
        if(ModelState.IsValid) 
        {
            var contatoCriado = await _contatoService.CriarContato(contato);
            if (contatoCriado.Sucesso)
            {
                var request = HttpContext.Request;
                var contatoCriadoId = (Contato)contatoCriado.Resposta!;
                var baseUrl = string.Concat($"{request.Scheme}://{request.Host}/api/{contatoCriadoId.Id}");
                return Created(new Uri(baseUrl), contatoCriado);
            }

            return StatusCode(500, contatoCriado);
        }

        return BadRequest();

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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> ObterContatoId(int id)
    {
        var contato = await _contatoService.ObterContatoId(id);
        if (contato.Sucesso)
        {
            return Ok(contato);    
        }

        return StatusCode(500, contato);
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarContato([FromBody] Contato contato)
    {
        var contatoAtualizado = await _contatoService.AtualizarContato(contato);
        if (contatoAtualizado.Sucesso)
        {
            return Ok(contatoAtualizado);
        }

        return StatusCode(500, contatoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirContato(int id)
    {
        var contatoExcluido = await _contatoService.ExcluirContato(id);
        if (contatoExcluido.Sucesso)
        {
            return Ok(contatoExcluido);
        }

        return StatusCode(500, contatoExcluido);
    }
}