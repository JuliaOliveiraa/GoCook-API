using GoCook_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace GoCook_API.Controllers;

[ApiController]
[Route("api/receitas")]
public class ReceitaController : ControllerBase
{
    private readonly Facade _facade;

    public ReceitaController(Facade facade)
    {
        _facade = facade;
    }

    [HttpPost]
    public async Task<IActionResult> CriarReceita([FromBody] Receita receita)
    {
        var novaReceita = await _facade.CriarReceita(receita);
        return Ok(novaReceita);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditarReceita(int id, [FromBody] Receita receita)
    {
        var receitaEditada = await _facade.EditarReceita(receita);
        return Ok(receitaEditada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarReceita(int id)
    {
        var sucesso = await _facade.DeletarReceita(id);

        if (sucesso)
        {
            return Ok("Receita deletada com sucesso.");
        }

        return NotFound("Receita não encontrada.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterReceitaPorId(int id)
    {
        var receita = await _facade.ObterReceitaPorId(id);

        if (receita != null)
        {
            return Ok(receita);
        }

        return NotFound("Receita não encontrada.");
    }

    [HttpGet("usuario/{idUsuario}")]
    public async Task<IActionResult> ListarReceitasPorUsuario(int idUsuario)
    {
        var receitas = await _facade.ObterReceitasPorUsuario(idUsuario);

        if (receitas != null)
        {
            return Ok(receitas);
        }

        return NotFound("Nenhuma receita encontrada para este usuário.");
    }
}



