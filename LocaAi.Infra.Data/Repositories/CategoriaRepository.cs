using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Infra.Data.Context;

namespace LocaAi.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(LocaAiContext db) : base(db) { }
    }
}
