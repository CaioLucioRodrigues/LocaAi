using LocaAi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LocaAi.Infra.Data.Context
{
    public class LocaAiContext : DbContext
    {
        public LocaAiContext()
        { }

        public LocaAiContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseIdentityColumns();

            builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.ClrType == typeof(string)).ToList()
                .ForEach(p => p.SetColumnType("varchar(100)"));

            builder.ApplyConfigurationsFromAssembly(typeof(LocaAiContext).Assembly);

            builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()).ToList()
                .ForEach(e => e.DeleteBehavior = DeleteBehavior.ClientSetNull);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //ConnectionString usada para o Migrations (Code First)
            builder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=LocaAiDbTest;Integrated Security=SSPI;");
        }

        public override int SaveChanges()
        {
            PreProcessData();
            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            PreProcessData();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void PreProcessData()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Ativo") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Ativo").CurrentValue = true;
                }
            }
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<CaracteristicaOpcao> CaracteristicaOpcoes { get; set; }
        public DbSet<CaracteristicaPorCategoria> CaracteristicasPorCategorias { get; set; }
    }
}
