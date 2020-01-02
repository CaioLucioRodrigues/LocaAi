using LocaAi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaAi.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DataCadastro");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasColumnName("Nome")
                .HasMaxLength(200);

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(2000)")
                .HasColumnName("Descricao")
                .HasMaxLength(2000);

            builder.Property(p => p.UsuarioId)
                .HasColumnName("UsuarioId")
                .IsRequired();

            builder.Property(p => p.CategoriaId)
                .HasColumnName("CategoriaId")
                .IsRequired();
        }
    }
}
