using LocaAi.Domain.Entities;
using LocaAi.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
            builder.HasDefaultSchema("LocaAiDb");
            new UsuarioConfiguration(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=LocaAiDb;Integrated Security=SSPI;");
        }

        public override int SaveChanges()
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
            return base.SaveChanges();
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
