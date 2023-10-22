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

        public async Task<Receita> CriarReceita(Receita receita)
        {
            _dbContext.Receitas.Add(receita);
            await _dbContext.SaveChangesAsync();
            return receita;
        }

        public async Task<Receita> EditarReceita(Receita receita)
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

        public async Task<List<Receita>> ObterReceitasPorUsuario(int idUsuario)
        {
            var receitas = await _dbContext.Receitas
                .Where(r => r.Cd_Usuario == idUsuario)
                .ToListAsync();

            return receitas;
        }

        public async Task<Receita> ObterReceitaPorId(int id)
        {
            var receita = await _dbContext.Receitas.FindAsync(id);
            return receita;
        }
    }
}
