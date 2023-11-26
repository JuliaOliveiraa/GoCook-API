using GoCook_API.DTO;
using GoCook_API.Interfaces;
using GoCook_API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

namespace GoCook_API.Services;

public class UsuarioService : IUsuarioService
{
    private readonly GoCookDbContext _dbContext;

    public UsuarioService(GoCookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Usuario> CriarUsuario(UsuarioCadastroDTO usuarioDTO)
    {
        var usuario = new Usuario
        {
            Nm_Usuario = usuarioDTO.Nm_Usuario,
            Nm_Email = usuarioDTO.Nm_Email,
            // Hash da senha usando Identity
            Ds_Senha = new PasswordHasher<Usuario>().HashPassword(null, usuarioDTO.Ds_Senha)
        };

        _dbContext.Usuarios.Add(usuario);
        await _dbContext.SaveChangesAsync();
        return usuario;
    }

    public async Task<LoginResponseDTO> Login(string email, string senha)
    {
        var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Nm_Email == email);

        if (usuario == null)
        {
            // Caso o e-mail não esteja cadastrado, retorna uma mensagem indicando que o usuário não existe
            return new LoginResponseDTO { Mensagem = "Usuário não cadastrado", Usuario = null };
        }

        var passwordHasher = new PasswordHasher<Usuario>();
        var result = passwordHasher.VerifyHashedPassword(null, usuario.Ds_Senha, senha);

        if (result == PasswordVerificationResult.Success)
        {
            // A senha está correta, retorna o usuário e uma mensagem indicando sucesso
            return new LoginResponseDTO { Mensagem = "Login bem-sucedido", Usuario = usuario };
        }

        // A senha está incorreta, retorna uma mensagem indicando que a senha está errada
        return new LoginResponseDTO { Mensagem = "Senha incorreta", Usuario = null };
    }


    public async Task<bool> DeletarUsuario(int id)
    {
        var usuario = await _dbContext.Usuarios.FindAsync(id);

        if (usuario != null)
        {
            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }

    //private string CriptografarSenha(string senha)
    //{
    //    using (var sha256 = SHA256.Create())
    //    {
    //        byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));

    //        // Converte os bytes em uma string hexadecimal
    //        StringBuilder builder = new StringBuilder();
    //        foreach (byte b in hashedBytes)
    //        {
    //            builder.Append(b.ToString("x2"));
    //        }

    //        return builder.ToString();
    //    }
    //}
}
