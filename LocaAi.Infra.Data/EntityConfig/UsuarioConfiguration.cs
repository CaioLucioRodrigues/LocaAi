using LocaAi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocaAi.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration
    {
        public UsuarioConfiguration(ModelBuilder builder)
        {
            builder.Entity<Usuario>(e =>
            {
                e.ToTable("Usuarios");
                e.HasKey(c => c.Id);
                e.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                e.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(150);
                e.Property(c => c.Senha).HasColumnName("Senha").HasMaxLength(15);
                e.Property(c => c.Email).HasColumnName("Email").HasMaxLength(150);
            });
        }
    }
}
