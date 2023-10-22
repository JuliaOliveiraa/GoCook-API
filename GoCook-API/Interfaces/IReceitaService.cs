using GoCook_API.Model;

namespace GoCook_API.Interfaces;

public interface IReceitaService
{
    Task<List<Receita>> ObterReceitasPorUsuario(int idUsuario);
    Task<Receita> CriarReceita(Receita receita);
    Task<Receita> EditarReceita(Receita receita);
    Task<bool> DeletarReceita(int id);
    Task<Receita> ObterReceitaPorId(int id);
}


