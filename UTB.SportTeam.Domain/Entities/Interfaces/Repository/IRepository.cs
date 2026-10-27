using System.Linq.Expressions;

namespace UTB.SportTeam.Domain.Entities.Interfaces.Repository
{
    /// <summary>
    /// Generické rozhraní Repository – základní CRUD operace pro libovolnou entitu.
    /// </summary>
    public interface IRepository<T, TKey> where T : IEntity<TKey> where TKey : notnull
    {
        T? GetById(TKey id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
    }
}
