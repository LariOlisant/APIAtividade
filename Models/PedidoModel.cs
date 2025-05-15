using API02.Enums;

namespace API02.Models
    {
    public class PedidoModel
    {
        public int Id { get; set; }
        public StatusPedido Status { get; set; }
        public string EnderecoEntrega { get; set; }
        public string MetodoPagamento { get; set; }
        public int? UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
    }
