using LocaAi.Domain.Entities;
using LocaAi.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

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
            builder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=LocaAiDb;");
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
