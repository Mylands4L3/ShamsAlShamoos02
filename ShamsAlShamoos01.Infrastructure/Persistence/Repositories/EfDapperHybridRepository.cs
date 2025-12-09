using Microsoft.EntityFrameworkCore;
using ShamsAlShamoos01.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShamsAlShamoos01.Infrastructure.Persistence.Repositories
{
    public class EfDapperHybridRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public EfDapperHybridRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================
        // EF Core CRUD
        // =====================
        public async Task<T> GetByIdAsync(object id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? skip = null, int? take = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<T> entities) => await _context.Set<T>().AddRangeAsync(entities);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Remove(T entity) => _context.Set<T>().Remove(entity);
        public void RemoveRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);

        // =====================
        // Transaction
        // =====================
        public async Task BeginTransactionAsync()
            => await _context.Database.BeginTransactionAsync();

        public async Task CommitAsync()
            => await _context.Database.CommitTransactionAsync();

        public async Task RollbackAsync()
            => await _context.Database.RollbackTransactionAsync();
    }
}
