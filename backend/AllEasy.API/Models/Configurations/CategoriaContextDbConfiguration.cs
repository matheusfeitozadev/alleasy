using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllEasy.API.Models.Configurations
{
    public class CategoriaContextDbConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA");
            builder.Property(x=> x.IdCategoria).HasColumnName("IDCATEGORIA");
            builder.Property(x=> x.Descricao).HasColumnName("DESCRICAO");
            builder.Property(x=> x.Ativo).HasColumnName("ATIVO");
        }
    }
}