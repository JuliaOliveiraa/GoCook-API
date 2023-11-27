using GoCook_API.DTO;
using GoCook_API.Interfaces;
using GoCook_API.Model;
using Microsoft.EntityFrameworkCore;

namespace GoCook_API.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly GoCookDbContext _dbContext;

        public ReceitaService(GoCookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Receita> CriarReceita(ReceitaDTO receitaDTO)
        {
            // Obtenha o usuário sem rastreamento (AsNoTracking) para evitar problemas com entidades rastreadas
            var usuario = await _dbContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Cd_Usuario == receitaDTO.Cd_Usuario);

            if (usuario == null)
            {
                // Se o usuário não existir, você pode tratar isso conforme necessário
                // Pode lançar uma exceção, retornar null ou realizar outra ação
                throw new Exception("Usuário não encontrado");
            }

            var novaReceita = new Receita
            {
                Nm_Receita = receitaDTO.Nm_Receita,
                Qt_TempoPreparo = receitaDTO.Qt_TempoPreparo,
                Ds_ModoPreparo = receitaDTO.Ds_ModoPreparo,
                Qt_PessoasServidas = receitaDTO.Qt_PessoasServidas,
                Cd_Usuario = receitaDTO.Cd_Usuario,
                Usuario = usuario
            };

            // Adicione os ingredientes à receita
            if (receitaDTO.Ingredientes != null)
            {
                novaReceita.Ingredientes = receitaDTO.Ingredientes.Select(i => new Ingrediente
                {
                    Cd_Receita = novaReceita.Cd_Receita,
                    Nm_Ingrediente = i.Nm_Ingrediente,
                    Qt_Ingrediente = i.Qt_Ingrediente,
                }).ToList();
            }

            // Adicione a receita ao contexto
            _dbContext.Receitas.Add(novaReceita);

            // Salve as alterações no banco de dados
            await _dbContext.SaveChangesAsync();
            return novaReceita;
        }


        public async Task<Receita> EditarReceita(ReceitaDTO receita)
        {
            var existingReceita = await _dbContext.Receitas.FindAsync(receita.Cd_Receita);

            if (existingReceita != null)
            {
                _dbContext.Entry(existingReceita).CurrentValues.SetValues(receita);
                await _dbContext.SaveChangesAsync();
            }

            return existingReceita;
        }

        public async Task<bool> DeletarReceita(int id)
        {
            var receita = await _dbContext.Receitas.FindAsync(id);

            if (receita != null)
            {
                _dbContext.Receitas.Remove(receita);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<ReceitaResponseDTO>> ObterReceitasPorUsuario(int idUsuario)
        {
            var receitas = await _dbContext.Receitas
                .Include(r => r.Ingredientes)
                .Where(r => r.Cd_Usuario == idUsuario)
                .ToListAsync();

            if (receitas == null || receitas.Count == 0)
            {
                // Retornar mensagem ao invés de lançar exceção
                return new List<ReceitaResponseDTO> { new ReceitaResponseDTO { Mensagem = "Este usuário ainda não tem nenhuma receita cadastrada." } };
            }

            var receitasDTO = receitas.Select(r => new ReceitaResponseDTO
            {
                Cd_Receita = r.Cd_Receita,
                Nm_Receita = r.Nm_Receita,
                Qt_TempoPreparo = r.Qt_TempoPreparo,
                Ds_ModoPreparo = r.Ds_ModoPreparo,
                Qt_PessoasServidas = r.Qt_PessoasServidas,
                Ingredientes = r.Ingredientes,
                Cd_Usuario = r.Cd_Usuario
            }).ToList();

            return receitasDTO;
        }


        public async Task<Receita> ObterReceitaPorId(int id)
        {
            var receita = await _dbContext.Receitas.FindAsync(id);
            return receita;
        }
    }
}
