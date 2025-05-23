﻿using API02.Models;

namespace API02.Repositorios.Interfaces
{
    public interface IPedidoProdutoRepositorio
    {
        Task<List<PedidoProdutoModel>> BuscarTodos();
        Task<PedidoProdutoModel> BuscarPorIds(int id);
        Task<PedidoProdutoModel> Adicionar(PedidoProdutoModel pedidoProduto);
        Task<PedidoProdutoModel> Atualizar(PedidoProdutoModel pedidoProduto, int id);
        Task<bool> Apagar(int id);
    }
}
