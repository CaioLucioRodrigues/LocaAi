using LocaAi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocaAi.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<IList<Usuario>> BuscarPorNome(string nome);
    }
}
