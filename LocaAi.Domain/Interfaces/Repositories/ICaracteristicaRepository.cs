using LocaAi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocaAi.Domain.Interfaces.Repositories
{
    public interface ICaracteristicaRepository : IRepositoryBase<Caracteristica>
    {
        Task<IEnumerable<Caracteristica>> BuscarPorCategoriaId(int categoriaId);
    }
}
