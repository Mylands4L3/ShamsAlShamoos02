using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ShamsAlShamoos01.Shared.Models;

namespace ShamsAlShamoos01.Infrastructure.Persistence.Repositories
{
    public class DapperGenericRepository : IDapperGenericRepository
    {
        public string ConnectionString { get; set; }

        public DapperGenericRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection CreateConnection() => new(ConnectionString);

        // =====================
        // Execute
        // =====================
        public void Execute(string sp, object param = null, int? timeout = null)
        {
            using var cnn = CreateConnection();
            cnn.Execute(sp, param, commandType: CommandType.StoredProcedure, commandTimeout: timeout);
        }

        public Task ExecuteAsync(string sp, object param = null, int? timeout = null)
        {
            using var cnn = CreateConnection();
            return cnn.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure, commandTimeout: timeout);
        }

        // =====================
        // Query
        // =====================
        public List<T> List<T>(string sp, object param = null, int? timeout = null)
        {
            using var cnn = CreateConnection();
            return cnn.Query<T>(sp, param, commandType: CommandType.StoredProcedure, commandTimeout: timeout).ToList();
        }

        public async Task<List<T>> ListAsync<T>(string sp, object param = null, int? timeout = null)
        {
            using var cnn = CreateConnection();
            var result = await cnn.QueryAsync<T>(sp, param, commandType: CommandType.StoredProcedure, commandTimeout: timeout);
            return result.ToList();
        }

        public T Single<T>(string sp, object param = null, int? timeout = null)
        {
            using var cnn = CreateConnection();
            return cnn.Query<T>(sp, param, commandType: CommandType.StoredProcedure, commandTimeout: timeout).FirstOrDefault();
        }

        public async Task<T> SingleAsync<T>(string sp, object param = null, int? timeout = null)
        {
            using var cnn = CreateConnection();
            var result = await cnn.QueryAsync<T>(sp, param, commandType: CommandType.StoredProcedure, commandTimeout: timeout);
            return result.FirstOrDefault();
        }

        // =====================
        // QueryMultiple for VartextAll
        // =====================
        public async Task<VartextAllModel> ListVartextAllAsync(string sp, object param = null, int? timeout = null)
        {
            using var cnn = CreateConnection();
            using var multi = await cnn.QueryMultipleAsync(sp, param, commandType: CommandType.StoredProcedure, commandTimeout: timeout);

            var model = new VartextAllModel();
            var props = typeof(VartextAllModel).GetProperties();

            foreach (var p in props)
            {
                var list = (await multi.ReadAsync<string>()).ToList();
                p.SetValue(model, list);
            }

            return model;
        }
    }
}
