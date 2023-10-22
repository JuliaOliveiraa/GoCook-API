using GoCook_API.Model;

namespace GoCook_API.Interfaces;

public interface IUsuarioService
{
    Task<Usuario> CriarUsuario(Usuario usuario);
    Task<Usuario> Login(string email, string senha);
    Task<bool> DeletarUsuario(int id);
}
