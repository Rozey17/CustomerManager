using CustomerManager.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;
using System.Configuration;
using System.Data;

namespace CustomerManager.DataAccess
{
    public class CustomerTypeRepository
    {
        private readonly string _connectionString;

        public CustomerTypeRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString ?? throw new ArgumentNullException("connectionString");
        }

        public async Task<bool> InsertAsync(CustomerTypeModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync("InsertCustomerType", model);

                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var output = await connection.ExecuteAsync("dbo.DeleteCustomerType", new { Id = id });
                return output > 0;
            }
        }

        public async Task<IEnumerable<CustomerTypeModel>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var customers = await connection.QueryAsync<CustomerTypeModel>("dbo.RetrieveCustomerTypes");

                return customers;
            }
        }
    }
}
