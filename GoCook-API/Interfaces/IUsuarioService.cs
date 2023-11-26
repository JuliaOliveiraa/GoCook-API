using GoCook_API.DTO;
using GoCook_API.Model;

namespace GoCook_API.Interfaces;

public interface IUsuarioService
{
    Task<Usuario> CriarUsuario(UsuarioCadastroDTO usuario);
    Task<LoginResponseDTO> Login(string email, string senha);
    Task<bool> DeletarUsuario(int id);
}
