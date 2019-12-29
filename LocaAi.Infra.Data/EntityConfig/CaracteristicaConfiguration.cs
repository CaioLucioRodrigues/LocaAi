using LocaAi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaAi.Infra.Data.EntityConfig
{
    public class CaracteristicaConfiguration : IEntityTypeConfiguration<Caracteristica>
    {
        public void Configure(EntityTypeBuilder<Caracteristica> builder)
        {
            builder.ToTable("Caracteristicas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(200)")
                .HasColumnName("Nome")
                .HasMaxLength(200);

            builder.Property(c => c.DataCadastro)
                .HasColumnName("DataCadastro");

            builder.HasMany(c => c.Opcoes)
                .WithOne(c => c.Caracteristica);
        }
    }
}
