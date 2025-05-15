using API02.Data;
using API02.Models;
using API02.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API02.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly SistemaDeVendasDbContext _dbContext;

        public CategoriaRepositorio(SistemaDeVendasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoriaModel> Adicionar(CategoriaModel categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> Apagar(int id)
        {
            var categoria = await BuscarPorId(id);
            if (categoria == null) return false;

            _dbContext.Categorias.Remove(categoria);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id)
        {
            var categoriaDb = await BuscarPorId(id);
            if (categoriaDb == null) return null;

            categoriaDb.Nome = categoria.Nome;
            categoriaDb.Status = categoria.Status;

            _dbContext.Categorias.Update(categoriaDb);
            await _dbContext.SaveChangesAsync();
            return categoriaDb;
        }

        public async Task<CategoriaModel> BuscarPorId(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CategoriaModel>> BuscarTodasCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
    }
}