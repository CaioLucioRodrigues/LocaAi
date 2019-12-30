using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocaAi.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(LocaAiContext db) : base(db)  { }

        public async Task<IList<Usuario>> BuscarPorNome(string nome)
        {
            return await Db.Usuarios
                .Where(u => u.Nome == nome)
                .ToListAsync();
        }
    }
}
