using API02.Data.Map;
using API02.Models;
using Microsoft.EntityFrameworkCore;

namespace API02.Data
{
    public class SistemaDeVendasDbContext : DbContext
    {
        public SistemaDeVendasDbContext(DbContextOptions<SistemaDeVendasDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<PedidoProdutoModel> PedidosProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new PedidoProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}