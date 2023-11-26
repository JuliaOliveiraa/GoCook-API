using GoCook_API.Model;

namespace GoCook_API.DTO;

public class LoginResponseDTO
{
    public string Mensagem { get; set; }
    public Usuario Usuario { get; set; }
}
