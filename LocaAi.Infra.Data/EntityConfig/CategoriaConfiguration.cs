using LocaAi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaAi.Infra.Data.EntityConfig
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(200)")
                .HasColumnName("Nome")
                .HasMaxLength(200);

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(2000)")
                .HasColumnName("Descricao")
                .HasMaxLength(2000);

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DataCadastro");

            builder.HasMany(p => p.Produtos)
                .WithOne(p => p.Categoria);
        }
    }
}
