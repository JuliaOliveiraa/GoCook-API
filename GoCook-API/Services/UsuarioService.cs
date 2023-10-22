using GoCook_API.Interfaces;
using GoCook_API.Model;
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

    public async Task<Usuario> CriarUsuario(Usuario usuario)
    {
        usuario.Ds_Senha = CriptografarSenha(usuario.Ds_Senha);

        _dbContext.Usuarios.Add(usuario);
        await _dbContext.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> Login(string email, string senha)
    {
        string senhaCriptografada = CriptografarSenha(senha);

        var usuario = await _dbContext.Usuarios
            .FirstOrDefaultAsync(u => u.Nm_Email == email && u.Ds_Senha == senhaCriptografada);

        return usuario;
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

    private string CriptografarSenha(string senha)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));

            // Converte os bytes em uma string hexadecimal
            StringBuilder builder = new StringBuilder();
            foreach (byte b in hashedBytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
