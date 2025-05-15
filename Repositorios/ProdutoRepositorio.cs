using API02.Data;
using API02.Models;
using API02.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API02.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SistemaDeVendasDbContext _dbContext;

        public ProdutoRepositorio(SistemaDeVendasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> Apagar(int id)
        {
            var produto = await BuscarPorId(id);
            if (produto == null) return false;

            _dbContext.Produtos.Remove(produto);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            var produtoDb = await BuscarPorId(id);
            if (produtoDb == null) return null;

            produtoDb.Nome = produto.Nome;
            produtoDb.Preco = produto.Preco;

            _dbContext.Produtos.Update(produtoDb);
            await _dbContext.SaveChangesAsync();
            return produtoDb;
        }

        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
    }
}

