using GoCook_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace GoCook_API.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly Facade _facade;

    public UsuarioController(Facade facade)
    {
        _facade = facade;
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] Usuario usuario)
    {
        var novoUsuario = await _facade.CriarUsuario(usuario);
        return Ok(novoUsuario);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var usuario = await _facade.Login(request.Email, request.Senha);

        if (usuario != null)
        {
            return Ok(usuario);
        }

        return Unauthorized("Credenciais inválidas");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarUsuario(int id)
    {
        var sucesso = await _facade.DeletarUsuario(id);

        if (sucesso)
        {
            return Ok("Usuário deletado com sucesso.");
        }

        return NotFound("Usuário não encontrado.");
    }
}
