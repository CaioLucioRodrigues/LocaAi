using LocaAi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaAi.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasColumnName("Nome")
                .HasMaxLength(200);

            builder.Property(p => p.Senha)
                .HasColumnType("varchar(15)")
                .HasColumnName("Senha")
                .HasMaxLength(15);

            builder.Property(p => p.Email)
                .HasColumnType("varchar(200)")
                .HasColumnName("Email")
                .HasMaxLength(200);

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DataCadastro");

            builder.Property(p => p.Pontuacao)
                .HasColumnName("Pontuacao");

            builder.HasMany(p => p.Produtos)
                .WithOne(p => p.Usuario);
        }
    }
}
