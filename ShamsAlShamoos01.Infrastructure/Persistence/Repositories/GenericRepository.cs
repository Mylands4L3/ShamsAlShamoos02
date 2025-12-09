using Microsoft.EntityFrameworkCore;
using ShamsAlShamoos01.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShamsAlShamoos01.Infrastructure.Persistence.Repositories
{
    public class GenericClass<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _table;

        public GenericClass(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _table = _context.Set<T>();
        }

        #region Create, Update, Delete

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _table.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _table.Attach(entity);
            }

            _table.Remove(entity);
        }

        public void DeleteById(object id)
        {
            T entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        #endregion

        #region Get Methods (Sync)

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        // بدون فیلتر و ترتیب
        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        // فقط فیلتر
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            if (filter == null)
            {
                return GetAll();
            }

            return _table.Where(filter).ToList();
        }

        public IEnumerable<T> GetAll(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _table;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        // ===========================
        // متد Get مشابه LINQ با overload
        // ===========================
        // فقط فیلتر
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return GetAll(filter, null);
        }

        // فقط ترتیب
        public IEnumerable<T> Get(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            return GetAll(null, orderBy);
        }


        public IEnumerable<T> Get(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            return GetAll(filter, orderBy);
        }

        #endregion

        #region Async Methods (EF Core)

        public async Task<T> GetByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            if (filter == null)
            {
                return await GetAllAsync();
            }

            return await _table.Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            IQueryable<T> query = _table.AsQueryable();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter,
                                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            IQueryable<T> query = _table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        #endregion
    }
}
