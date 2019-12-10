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
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).HasColumnType("varchar(200)").HasColumnName("Nome").HasMaxLength(200);
            builder.Property(c => c.Senha).HasColumnType("varchar(15)").HasColumnName("Senha").HasMaxLength(15);
            builder.Property(c => c.Email).HasColumnType("varchar(200)").HasColumnName("Email").HasMaxLength(200);
            builder.Property(c => c.DataCadastro).HasColumnName("DataCadastro");
            builder.Property(c => c.Pontuacao).HasColumnName("Pontuacao");
        }
    }
}
