using LocaAi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocaAi.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<IEnumerable<Usuario>> BuscarPorNome(string nome);
    }
}
