using LocaAi.Domain.Entities;
using LocaAi.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
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

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
