using AllEasy.API.Models;
using AllEasy.API.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AllEasy.API.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options){

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
            .HasMany(x => x.Produtos)
            .WithOne(x => x.Categoria).IsRequired();

            modelBuilder.Entity<Produto>()
                .HasOne(x => x.Categoria)
                .WithMany(x=> x.Produtos)
                .HasForeignKey(x=> x.IdCategoria);

            modelBuilder.ApplyConfiguration(new CategoriaContextDbConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoContextDbConfiguration());
        }
    }
}