using LocaAi.Domain.Entities;
using LocaAi.Domain.Interfaces.Repositories;
using LocaAi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LocaAi.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : LocaAiEntityBase, new()
    {
        protected readonly LocaAiContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(LocaAiContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> CarregarPorID(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> CarregarTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IList<TEntity>> CarregarTodosAtivos()
        {
            return await Buscar(e => e.Ativo);

        }

        public async Task<IList<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task AdicionarOuAtualizar(TEntity entity)
        {
            if (entity?.Id == 0)
                await Adicionar(entity);
            else
                await Atualizar(entity);
        }

        public virtual async Task Remover(int id)
        {
            var entity = await CarregarPorID(id);
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges() => await Db.SaveChangesAsync();

        public virtual void Dispose()
        {
            Db?.Dispose();
        }
    }
}
