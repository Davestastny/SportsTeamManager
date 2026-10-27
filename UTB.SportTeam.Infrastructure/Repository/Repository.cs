using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UTB.SportTeam.Domain.Entities.Interfaces;
using UTB.SportTeam.Domain.Entities.Interfaces.Repository;

namespace UTB.SportTeam.Infrastructure.Repository
{
    /// <summary>
    /// Generická implementace Repository pattern nad EF Core.
    /// Funguje pro libovolnou entitu, která implementuje IEntity&lt;TKey&gt;.
    /// </summary>
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class, IEntity<TKey> where TKey : notnull
    {
        private readonly DbSet<T> dbSet;
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbSet = dbContext.Set<T>();
            this.dbContext = dbContext;
        }

        public virtual T? GetById(TKey id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public virtual void Edit(T entity)
        {
            dbSet.Update(entity);
            dbContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
