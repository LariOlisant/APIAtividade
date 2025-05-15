using API02.Data;
using API02.Models;
using API02.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API02.Repositorios
{
    public class PedidoProdutoRepositorio : IPedidoProdutoRepositorio
    {
        private readonly SistemaDeVendasDbContext _dbContext;

        public PedidoProdutoRepositorio(SistemaDeVendasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PedidoProdutoModel> Adicionar(PedidoProdutoModel pedidoProduto)
        {
            await _dbContext.PedidosProdutos.AddAsync(pedidoProduto);
            await _dbContext.SaveChangesAsync();
            return pedidoProduto;
        }

        public async Task<bool> Apagar(int id)
        {
            var item = await BuscarPorIds(id);
            if (item == null) return false;

            _dbContext.PedidosProdutos.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidoProdutoModel> Atualizar(PedidoProdutoModel pedidoProduto, int id)
        {
            var itemDb = await BuscarPorIds(id);
            if (itemDb == null) return null;

            itemDb.PedidoId = pedidoProduto.PedidoId;
            itemDb.ProdutoId = pedidoProduto.ProdutoId;
            itemDb.Quantidade = pedidoProduto.Quantidade;
            itemDb.PrecoUnitario = pedidoProduto.PrecoUnitario;

            _dbContext.PedidosProdutos.Update(itemDb);
            await _dbContext.SaveChangesAsync();
            return itemDb;
        }

        public async Task<PedidoProdutoModel> BuscarPorIds(int id)
        {
            return await _dbContext.PedidosProdutos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PedidoProdutoModel>> BuscarTodos()
        {
            return await _dbContext.PedidosProdutos.ToListAsync();
        }
    }
}