using LocaAi.Domain.Entities;
using System.Collections.Generic;

namespace LocaAi.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        IEnumerable<Usuario> BuscarPorNome(string nome);
    }
}
