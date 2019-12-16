using LocaAi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocaAi.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<IEnumerable<Produto>> BuscarPorUsuarioId(int produtoId);

        Task<Produto> BuscarPorProdutoECategoria(int usuarioId);
    }
}
