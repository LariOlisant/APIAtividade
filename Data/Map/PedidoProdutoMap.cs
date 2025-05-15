using API02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API02.Data.Map
{
    public class PedidoProdutoMap : IEntityTypeConfiguration<PedidoProdutoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoProdutoModel> builder)
        {
            builder.HasKey(x => new { x.PedidoId, x.ProdutoId });

            builder.Property(x => x.Quantidade).IsRequired();

            builder.Property(x => x.PedidoId);

            builder.Property(x => x.ProdutoId);
        }
    }
}
