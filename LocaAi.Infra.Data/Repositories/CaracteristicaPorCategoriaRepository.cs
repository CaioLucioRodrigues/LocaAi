using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Infra.Data.Context;

namespace LocaAi.Infra.Data.Repositories
{
    public class CaracteristicaPorCategoriaRepository : RepositoryBase<CaracteristicaPorCategoria>, ICaracteristicaPorCategoriaRepository
    {
        public CaracteristicaPorCategoriaRepository(LocaAiContext db) : base(db) { }
    }
}
