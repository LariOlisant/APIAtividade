﻿using API02.Models;

namespace API02.Repositorios.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<List<PedidoModel>> BuscarTodosPedidos();
        Task<PedidoModel> BuscarPorId(int id);
        Task<PedidoModel> Adicionar(PedidoModel pedido);
        Task<PedidoModel> Atualizar(PedidoModel pedido, int id);
        Task<bool> Apagar(int id);
    }
}
