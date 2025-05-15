using API02.Data;
using API02.Models;
using API02.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API02.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly SistemaDeVendasDbContext _dbContext;

        public PedidoRepositorio(SistemaDeVendasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PedidoModel> Adicionar(PedidoModel pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<bool> Apagar(int id)
        {
            var pedido = await BuscarPorId(id);
            if (pedido == null) return false;

            _dbContext.Pedidos.Remove(pedido);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidoModel> Atualizar(PedidoModel pedido, int id)
        {
            var pedidoDb = await BuscarPorId(id);
            if (pedidoDb == null) return null;

            pedidoDb.EnderecoEntrega = pedido.EnderecoEntrega;
            pedidoDb.Status = pedido.Status;
            pedidoDb.MetodoPagamento = pedido.MetodoPagamento;

            _dbContext.Pedidos.Update(pedidoDb);
            await _dbContext.SaveChangesAsync();
            return pedidoDb;
        }

        public async Task<PedidoModel> BuscarPorId(int id)
        {
            return await _dbContext.Pedidos.Include(x=> x.Usuario).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PedidoModel>> BuscarTodosPedidos()
        {
            return await _dbContext.Pedidos.Include(x => x.Usuario).ToListAsync();
        }
    }
}
