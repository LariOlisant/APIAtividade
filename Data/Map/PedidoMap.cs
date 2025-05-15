using API02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API02.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<PedidoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EnderecoEntrega).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(180);
            builder.Property(x => x.MetodoPagamento).IsRequired().HasMaxLength(100);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(100);
        }
    }
}
