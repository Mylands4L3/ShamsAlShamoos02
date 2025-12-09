using ShamsAlShamoos01.Infrastructure.Persistence.Repositories;
using ShamsAlShamoos01.Shared.Entities;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<T> Repository<T>() where T : class;
    Task<int> SaveChangesAsync();

    // Dapper generic repository
    IDapperGenericRepository Dapper { get; }

    // اضافه کردن متد InsertAsync
    Task InsertAsync<T>(T entity) where T : class;
    IBaseRepository<HistoryRegisterKala01> HistoryRegisterKala01UW { get; }
        
}
