using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamsAlShamoos01.Infrastructure.Persistence.Repositories
{
    public class VartextAllModel
    {
        public List<string> Vartext01 { get; set; } = new();
        public List<string> Vartext02 { get; set; } = new();
        public List<string> Vartext03 { get; set; } = new();
        public List<string> Vartext04 { get; set; } = new();
        public List<string> Vartext05 { get; set; } = new();
        public List<string> Vartext06 { get; set; } = new();
        public List<string> Vartext07 { get; set; } = new();
        public List<string> Vartext08 { get; set; } = new();
        public List<string> Vartext09 { get; set; } = new();
        public List<string> Vartext10 { get; set; } = new();
        public List<string> Vartext11 { get; set; } = new();
        public List<string> Vartext12 { get; set; } = new();
        public List<string> Vartext13 { get; set; } = new();
        public List<string> Vartext14 { get; set; } = new();
        public List<string> Vartext15 { get; set; } = new();
        public List<string> Vartext16 { get; set; } = new();
        public List<string> Vartext17 { get; set; } = new();
        public List<string> Vartext18 { get; set; } = new();
        public List<string> Vartext19 { get; set; } = new();
        public List<string> Vartext20 { get; set; } = new();
    }

    public interface IDapperGenericRepository
    {
        string ConnectionString { get; set; }

        #region Sync

        void Execute(string name);
        void Execute(string name, object param);
        void Execute(string name, object param, int? commandTimeout);

        void QueryExecute(string name);
        void QueryExecute(string name, object param);
        void QueryExecute(string name, object param, int? commandTimeout);

        List<T> List<T>(string name);
        List<T> List<T>(string name, object param);
        List<T> List<T>(string name, object param, int? commandTimeout);

        T Single<T>(string name);
        T Single<T>(string name, object param);
        T Single<T>(string name, object param, int? commandTimeout);

        List<T> ListFilter<T>(string name);
        List<T> ListFilter<T>(string name, object param);
        List<T> ListFilter<T>(string name, object param, int? commandTimeout);

        (List<string> Vartext01, List<string> Vartext02, List<string> Vartext03, List<string> Vartext04,
         List<string> Vartext05, List<string> Vartext06, List<string> Vartext07, List<string> Vartext08,
         List<string> Vartext09, List<string> Vartext10, List<string> Vartext11, List<string> Vartext12,
         List<string> Vartext13, List<string> Vartext14, List<string> Vartext15, List<string> Vartext16,
         List<string> Vartext17, List<string> Vartext18, List<string> Vartext19, List<string> Vartext20)
         ListVartextAll(string storedProcedure);
        (List<string> Vartext01, List<string> Vartext02, List<string> Vartext03, List<string> Vartext04,
         List<string> Vartext05, List<string> Vartext06, List<string> Vartext07, List<string> Vartext08,
         List<string> Vartext09, List<string> Vartext10, List<string> Vartext11, List<string> Vartext12,
         List<string> Vartext13, List<string> Vartext14, List<string> Vartext15, List<string> Vartext16,
         List<string> Vartext17, List<string> Vartext18, List<string> Vartext19, List<string> Vartext20)
         ListVartextAll(string storedProcedure, object param);
        (List<string> Vartext01, List<string> Vartext02, List<string> Vartext03, List<string> Vartext04,
         List<string> Vartext05, List<string> Vartext06, List<string> Vartext07, List<string> Vartext08,
         List<string> Vartext09, List<string> Vartext10, List<string> Vartext11, List<string> Vartext12,
         List<string> Vartext13, List<string> Vartext14, List<string> Vartext15, List<string> Vartext16,
         List<string> Vartext17, List<string> Vartext18, List<string> Vartext19, List<string> Vartext20)
         ListVartextAll(string storedProcedure, object param, int? commandTimeout);

        #endregion

        #region Async

        Task ExecuteAsync(string name);
        Task ExecuteAsync(string name, object param);
        Task ExecuteAsync(string name, object param, int? commandTimeout);

        Task QueryExecuteAsync(string name);
        Task QueryExecuteAsync(string name, object param);
        Task QueryExecuteAsync(string name, object param, int? commandTimeout);

        Task<List<T>> ListAsync<T>(string name);
        Task<List<T>> ListAsync<T>(string name, object param);
        Task<List<T>> ListAsync<T>(string name, object param, int? commandTimeout);

        Task<T> SingleAsync<T>(string name);
        Task<T> SingleAsync<T>(string name, object param);
        Task<T> SingleAsync<T>(string name, object param, int? commandTimeout);

        Task<List<T>> ListFilterAsync<T>(string name);
        Task<List<T>> ListFilterAsync<T>(string name, object param);
        Task<List<T>> ListFilterAsync<T>(string name, object param, int? commandTimeout);

        Task<VartextAllModel> ListVartextAllAsync(string storedProcedure);
        Task<VartextAllModel> ListVartextAllAsync(string storedProcedure, object param);
        Task<VartextAllModel> ListVartextAllAsync(string storedProcedure, object param, int? commandTimeout);

        #endregion
    }

    public class DapperGenericRepository : IDapperGenericRepository
    {
        public string ConnectionString { get; set; }

        public DapperGenericRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        #region Sync

        // Execute
        public void Execute(string name) => Execute(name, null, null);
        public void Execute(string name, object param) => Execute(name, param, null);
        public void Execute(string name, object param, int? commandTimeout)
        {
            using var cnn = new SqlConnection(ConnectionString);
            cnn.Execute(name, param, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
        }

        // QueryExecute
        public void QueryExecute(string name) => Execute(name);
        public void QueryExecute(string name, object param) => Execute(name, param);
        public void QueryExecute(string name, object param, int? commandTimeout) => Execute(name, param, commandTimeout);

        // List
        public List<T> List<T>(string name) => List<T>(name, null, null);
        public List<T> List<T>(string name, object param) => List<T>(name, param, null);
        public List<T> List<T>(string name, object param, int? commandTimeout)
        {
            using var cnn = new SqlConnection(ConnectionString);
            var result = cnn.Query<T>(name, param, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            return result?.ToList() ?? new List<T>();
        }

        // Single
        public T Single<T>(string name) => Single<T>(name, null, null);
        public T Single<T>(string name, object param) => Single<T>(name, param, null);
        public T Single<T>(string name, object param, int? commandTimeout)
        {
            using var cnn = new SqlConnection(ConnectionString);
            return cnn.Query<T>(name, param, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout).FirstOrDefault();
        }

        // ListFilter
        public List<T> ListFilter<T>(string name) => ListFilter<T>(name, null, null);
        public List<T> ListFilter<T>(string name, object param) => ListFilter<T>(name, param, null);
        public List<T> ListFilter<T>(string name, object param, int? commandTimeout) => List<T>(name, param, commandTimeout);

        // ListVartextAll
        public (List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>,
                List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>)
            ListVartextAll(string storedProcedure) => ListVartextAll(storedProcedure, null, null);

        public (List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>,
                List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>)
            ListVartextAll(string storedProcedure, object param) => ListVartextAll(storedProcedure, param, null);

        public (List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>,
                List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>, List<string>)
            ListVartextAll(string storedProcedure, object param, int? commandTimeout)
        {
            using var cnn = new SqlConnection(ConnectionString);
            using var multi = cnn.QueryMultiple(storedProcedure, param, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            return (
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList(),
                multi.Read<string>().ToList()
            );
        }

        #endregion

        #region Async

        // ExecuteAsync
        public Task ExecuteAsync(string name) => ExecuteAsync(name, null, null);
        public Task ExecuteAsync(string name, object param) => ExecuteAsync(name, param, null);
        public async Task ExecuteAsync(string name, object param, int? commandTimeout)
        {
            using var cnn = new SqlConnection(ConnectionString);
            await cnn.ExecuteAsync(name, param, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
        }

        // QueryExecuteAsync
        public Task QueryExecuteAsync(string name) => ExecuteAsync(name);
        public Task QueryExecuteAsync(string name, object param) => ExecuteAsync(name, param);
        public Task QueryExecuteAsync(string name, object param, int? commandTimeout) => ExecuteAsync(name, param, commandTimeout);

        // ListAsync
        public Task<List<T>> ListAsync<T>(string name) => ListAsync<T>(name, null, null);
        public Task<List<T>> ListAsync<T>(string name, object param) => ListAsync<T>(name, param, null);
        public async Task<List<T>> ListAsync<T>(string name, object param, int? commandTimeout)
        {
            using var cnn = new SqlConnection(ConnectionString);
            var result = await cnn.QueryAsync<T>(name, param, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            return result?.ToList() ?? new List<T>();
        }

        // SingleAsync
        public Task<T> SingleAsync<T>(string name) => SingleAsync<T>(name, null, null);
        public Task<T> SingleAsync<T>(string name, object param) => SingleAsync<T>(name, param, null);
        public async Task<T> SingleAsync<T>(string name, object param, int? commandTimeout)
        {
            using var cnn = new SqlConnection(ConnectionString);
            var result = await cnn.QueryAsync<T>(name, param, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            return result.FirstOrDefault();
        }

        // ListFilterAsync
        public Task<List<T>> ListFilterAsync<T>(string name) => ListFilterAsync<T>(name, null, null);
        public Task<List<T>> ListFilterAsync<T>(string name, object param) => ListFilterAsync<T>(name, param, null);
        public Task<List<T>> ListFilterAsync<T>(string name, object param, int? commandTimeout) => ListAsync<T>(name, param, commandTimeout);

        // ListVartextAllAsync
        public Task<VartextAllModel> ListVartextAllAsync(string storedProcedure) => ListVartextAllAsync(storedProcedure, null, null);
        public Task<VartextAllModel> ListVartextAllAsync(string storedProcedure, object param) => ListVartextAllAsync(storedProcedure, param, null);
        public async Task<VartextAllModel> ListVartextAllAsync(string storedProcedure, object param, int? commandTimeout)
        {
            using var cnn = new SqlConnection(ConnectionString);
            var multi = await cnn.QueryMultipleAsync(storedProcedure, param, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout);
            return new VartextAllModel
            {
                Vartext01 = (await multi.ReadAsync<string>()).ToList(),
                Vartext02 = (await multi.ReadAsync<string>()).ToList(),
                Vartext03 = (await multi.ReadAsync<string>()).ToList(),
                Vartext04 = (await multi.ReadAsync<string>()).ToList(),
                Vartext05 = (await multi.ReadAsync<string>()).ToList(),
                Vartext06 = (await multi.ReadAsync<string>()).ToList(),
                Vartext07 = (await multi.ReadAsync<string>()).ToList(),
                Vartext08 = (await multi.ReadAsync<string>()).ToList(),
                Vartext09 = (await multi.ReadAsync<string>()).ToList(),
                Vartext10 = (await multi.ReadAsync<string>()).ToList(),
                Vartext11 = (await multi.ReadAsync<string>()).ToList(),
                Vartext12 = (await multi.ReadAsync<string>()).ToList(),
                Vartext13 = (await multi.ReadAsync<string>()).ToList(),
                Vartext14 = (await multi.ReadAsync<string>()).ToList(),
                Vartext15 = (await multi.ReadAsync<string>()).ToList(),
                Vartext16 = (await multi.ReadAsync<string>()).ToList(),
                Vartext17 = (await multi.ReadAsync<string>()).ToList(),
                Vartext18 = (await multi.ReadAsync<string>()).ToList(),
                Vartext19 = (await multi.ReadAsync<string>()).ToList(),
                Vartext20 = (await multi.ReadAsync<string>()).ToList(),
            };
        }

        #endregion
    }
}
