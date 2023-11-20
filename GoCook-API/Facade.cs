using GoCook_API.DTO;
using GoCook_API.Interfaces;
using GoCook_API.Model;

namespace GoCook_API;

public class Facade
{
    private readonly IUsuarioService _usuarioService;
    private readonly IReceitaService _receitaService;

    public Facade(IUsuarioService usuarioService, IReceitaService receitaService)
    {
        _usuarioService = usuarioService;
        _receitaService = receitaService;
    }

    // Métodos relacionados a Usuários
    public Task<Usuario> CriarUsuario(UsuarioCadastroDTO usuario)
    {
        return _usuarioService.CriarUsuario(usuario);
    }

    public Task<Usuario> Login(string email, string senha)
    {
        return _usuarioService.Login(email, senha);
    }

    public Task<bool> DeletarUsuario(int id)
    {
        return _usuarioService.DeletarUsuario(id);
    }

    // Métodos relacionados a Receitas
    public Task<Receita> CriarReceita(Receita receita)
    {
        return _receitaService.CriarReceita(receita);
    }

    public Task<Receita> EditarReceita(Receita receita)
    {
        return _receitaService.EditarReceita(receita);
    }

    public Task<bool> DeletarReceita(int id)
    {
        return _receitaService.DeletarReceita(id);
    }
    public Task<List<Receita>> ObterReceitasPorUsuario(int idUsuario)
    {
        return _receitaService.ObterReceitasPorUsuario(idUsuario);
    }

    public Task<Receita> ObterReceitaPorId(int id)
    {
        return _receitaService.ObterReceitaPorId(id);
    }
}
