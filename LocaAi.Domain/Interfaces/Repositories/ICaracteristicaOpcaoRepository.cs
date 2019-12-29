using LocaAi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocaAi.Domain.Interfaces.Repositories
{
    public interface ICaracteristicaOpcaoRepository : IRepositoryBase<CaracteristicaOpcao>
    {
        public Task<IEnumerable<CaracteristicaOpcao>> BuscarPorCaracteristicaId(int caracteristicaId);
    }
}
