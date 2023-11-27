using GoCook_API.DTO;
using GoCook_API.Model;

namespace GoCook_API.Interfaces;

public interface IReceitaService
{
    Task<List<ReceitaResponseDTO>> ObterReceitasPorUsuario(int idUsuario);
    Task<Receita> CriarReceita(ReceitaDTO receita);
    Task<Receita> EditarReceita(ReceitaDTO receita);
    Task<bool> DeletarReceita(int id);
    Task<Receita> ObterReceitaPorId(int id);
}


