using LocaAi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaAi.Infra.Data.EntityConfig
{
    public class CaracteristicaOpcaoConfiguration : IEntityTypeConfiguration<CaracteristicaOpcao>
    {
        public void Configure(EntityTypeBuilder<CaracteristicaOpcao> builder)
        {
            builder.ToTable("CaracteristicaOpcoes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasColumnName("Nome")
                .HasMaxLength(200);

            builder.Property(c => c.DataCadastro)
                .HasColumnName("DataCadastro");
        }
    }
}
