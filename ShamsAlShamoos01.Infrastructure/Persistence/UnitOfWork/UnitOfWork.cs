using ShamsAlShamoos01.Infrastructure.Persistence.Contexts;
using ShamsAlShamoos01.Infrastructure.Persistence.Repositories;
using ShamsAlShamoos01.Shared.Entities;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ShamsAlShamoos01.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ConcurrentDictionary<Type, Lazy<object>> _repositories = new();

        public UnitOfWork(ApplicationDbContext context, IDapperGenericRepository dapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Dapper = dapper ?? throw new ArgumentNullException(nameof(dapper));
        }

        // ========================
        // Repository<T>
        // ========================
        public IBaseRepository<T> Repository<T>() where T : class
        {
            var repo = _repositories.GetOrAdd(
                typeof(T),
                t => new Lazy<object>(() => new GenericClass<T>(_context)) // GenericClass<T> همان IBaseRepository<T>
            );
            return (IBaseRepository<T>)repo.Value;
        }

        // ========================
        // Dapper
        // ========================
        public IDapperGenericRepository Dapper { get; }

        // ========================
        // Example property
        // ========================
        public IBaseRepository<HistoryRegisterKala01> HistoryRegisterKala01UW => Repository<HistoryRegisterKala01>();

        // ========================
        // Save / Transaction
        // ========================
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // ========================
        // Dispose / Async Dispose
        // ========================
        public void Dispose()
        {
            _repositories.Clear();
            _context.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            _repositories.Clear();
            await _context.DisposeAsync();
        }
        public async Task InsertAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

    }
}
