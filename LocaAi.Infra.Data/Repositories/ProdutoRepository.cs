using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocaAi.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(LocaAiContext db) : base(db) { }

        public async Task<IEnumerable<Produto>> BuscarPorUsuarioId(int usuarioId)
        {
            return await Db.Produtos
                .Where(u => u.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
