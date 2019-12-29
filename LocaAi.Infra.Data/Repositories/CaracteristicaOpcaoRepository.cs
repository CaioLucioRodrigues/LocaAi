using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocaAi.Infra.Data.Repositories
{
    public class CaracteristicaOpcaoRepository : RepositoryBase<CaracteristicaOpcao>, ICaracteristicaOpcaoRepository
    {
        public CaracteristicaOpcaoRepository(LocaAiContext db) : base(db) { }

        public async Task<IEnumerable<CaracteristicaOpcao>> BuscarPorCaracteristicaId(int caracteristicaId)
        {
            return await Db.CaracteristicaOpcoes
                .Where(c => c.CaracteristicaId == caracteristicaId)
                .ToListAsync();
        }
    }
}
