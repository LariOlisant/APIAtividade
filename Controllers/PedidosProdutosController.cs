using API02.Models;
using API02.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosProdutosController : ControllerBase
    {
        private readonly IPedidoProdutoRepositorio _pedidoProdutoRepositorio;

        public PedidosProdutosController(IPedidoProdutoRepositorio pedidoProdutoRepositorio)
        {
            _pedidoProdutoRepositorio = pedidoProdutoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoProdutoModel>>> BuscarTodos()
        {
            var pedidosProdutos = await _pedidoProdutoRepositorio.BuscarTodos();
            return Ok(pedidosProdutos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoProdutoModel>> BuscarPorIds(int id)
        {
            var pedidoProduto = await _pedidoProdutoRepositorio.BuscarPorIds(id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }
            return Ok(pedidoProduto);
        }

        [HttpPost]
        public async Task<ActionResult<PedidoProdutoModel>> Adicionar([FromBody] PedidoProdutoModel pedidoProduto)
        {
            var novo = await _pedidoProdutoRepositorio.Adicionar(pedidoProduto);
            return Ok(novo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoProdutoModel>> Atualizar(int id, [FromBody] PedidoProdutoModel pedidoProduto)
        {
            pedidoProduto.Id = id;
            PedidoProdutoModel atualizado = await _pedidoProdutoRepositorio.Atualizar(pedidoProduto, id);
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            var apagado = await _pedidoProdutoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
