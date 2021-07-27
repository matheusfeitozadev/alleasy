using AllEasy.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllEasy.API.Context
{
    public class ProdutoContextDbConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");
            builder.Property(x=> x.IdProduto).HasColumnName("IDPRODUTO");
            builder.Property(x=> x.IdCategoria).HasColumnName("IDCATEGORIA");
            builder.Property(x=> x.Nome).HasColumnName("NOME");
            builder.Property(x=> x.Descricao).HasColumnName("DESCRICAO");
            builder.Property(x=> x.Preco).HasColumnName("PRECO");
            builder.Property(x=> x.Quantidade).HasColumnName("QUANTIDADE");
            builder.Property(x=> x.Ativo).HasColumnName("ATIVO");
        }
    }
}