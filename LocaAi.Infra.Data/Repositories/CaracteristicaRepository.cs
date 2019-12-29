using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAi.Infra.Data.Repositories
{
    public class CaracteristicaRepository : RepositoryBase<Caracteristica>, ICaracteristicaRepository
    {
        private readonly ICaracteristicaOpcaoRepository _caracteristicaOpcaoRepository;

        public CaracteristicaRepository(LocaAiContext db,
                                        ICaracteristicaOpcaoRepository caracteristicaOpcaoRepository) : base(db) 
        {
            _caracteristicaOpcaoRepository = caracteristicaOpcaoRepository;
        }

        public async Task<IEnumerable<Caracteristica>> BuscarPorCategoriaId(int categoriaId)
        {
            return await Db.Categorias
                .Where(c => c.Id == categoriaId)
                .SelectMany(c => c.CaracteristicasPorCategorias)
                .Select(cp => cp.Caracteristica)
                .ToListAsync();
        }
    }
}
