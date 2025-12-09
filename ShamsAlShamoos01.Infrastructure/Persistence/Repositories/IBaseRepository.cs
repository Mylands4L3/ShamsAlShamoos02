using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShamsAlShamoos01.Infrastructure.Persistence.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        // =====================
        // EF Core CRUD
        // =====================
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? skip = null, int? take = null
        );
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        // =====================
        // Transaction
        // =====================
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
