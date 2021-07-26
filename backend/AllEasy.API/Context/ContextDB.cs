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
            modelBuilder.ApplyConfiguration(new ProdutoContextDbConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaContextDbConfiguration());
        }
    }
}