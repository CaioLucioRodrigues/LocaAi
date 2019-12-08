using System.Collections.Generic;
using System.Linq;
using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;

namespace LocaAi.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public IEnumerable<Usuario> BuscarPorNome(string nome)
        {
            return Db.Usuarios.Where(u => u.Nome == nome);
        }
    }
}
