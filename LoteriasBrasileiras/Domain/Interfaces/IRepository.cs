using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Adicionar(TEntity obj);
        void Adicionar(IEnumerable<TEntity> objs);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(int id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
