using LocaAi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LocaAi.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : LocaAiEntityBase
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> CarregarPorID(int id);
        Task<IList<TEntity>> CarregarTodos();
        Task<IList<TEntity>> CarregarTodosAtivos();
        Task Atualizar(TEntity entity);
        Task AdicionarOuAtualizar(TEntity entity);
        Task Remover(int id);
        Task<IList<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
