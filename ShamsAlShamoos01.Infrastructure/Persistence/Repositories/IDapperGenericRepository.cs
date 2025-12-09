using ShamsAlShamoos01.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShamsAlShamoos01.Infrastructure.Persistence.Repositories
{
    public interface IDapperGenericRepository
    {
        string ConnectionString { get; set; }

        // Execute
        void Execute(string sp, object param = null, int? commandTimeout = null);
        Task ExecuteAsync(string sp, object param = null, int? commandTimeout = null);

        // Query
        List<T> List<T>(string sp, object param = null, int? commandTimeout = null);
        Task<List<T>> ListAsync<T>(string sp, object param = null, int? commandTimeout = null);

        T Single<T>(string sp, object param = null, int? commandTimeout = null);
        Task<T> SingleAsync<T>(string sp, object param = null, int? commandTimeout = null);

        // QueryMultiple for VartextAll
        Task<VartextAllModel> ListVartextAllAsync(string sp, object param = null, int? commandTimeout = null);
    }
}
