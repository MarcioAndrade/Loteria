using Domain;
using System;
using System.Linq;
using Domain.Interfaces;
using Repository.Context;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected LoteriaContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(LoteriaContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Adicionar(IEnumerable<TEntity> objs)
        {
            DbSet.AddRange(objs);
        }

        public virtual void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
