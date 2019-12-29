using LocaAi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaAi.Infra.Data.EntityConfig
{
    public class CaracteristicaPorCategoriaConfiguration : IEntityTypeConfiguration<CaracteristicaPorCategoria>
    {
        public void Configure(EntityTypeBuilder<CaracteristicaPorCategoria> builder)
        {
            builder.ToTable("CaracteristicasPorCategorias");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Categoria)
                 .WithMany(p => p.CaracteristicasPorCategorias)
                 .HasForeignKey(pt => pt.CategoriaId);

            builder.HasOne(c => c.Caracteristica)
                 .WithMany(p => p.CaracteristicasPorCategorias)
                 .HasForeignKey(pt => pt.CaracteristicaId);
        }
    }
}
