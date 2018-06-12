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

        #region Manipulating Customer Types

        // An async method to insert data in the database using Insight.Database
        // We insert a CustomerTypeModel as the parameter for the stored procedure
        public async Task<bool> InsertAsync(CustomerTypeModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // we use the 'InsertCustomerType' store procedure from the database
                var result = await connection.ExecuteAsync("InsertCustomerType", model);

                return result > 0;
            }
        }

        // Create an async method to delete data from the database using Insight.Database 
        // We delete a a specific Id as the parameter for the stored procedure
        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // we use the 'DeleteCustomerType' store procedure from the database
                var output = await connection.ExecuteAsync("dbo.DeleteCustomerType", new { Id = id });
                return output > 0;
            }
        }

        // Create an async method to retrieve data from the database using Insight.Database 
        // We display a CustomerTypeModel
        public async Task<IEnumerable<CustomerTypeModel>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // The 'RetrieveCustomerTypes' is a store procedure from the database
                var customers = await connection.QueryAsync<CustomerTypeModel>("dbo.RetrieveCustomerTypes");

                return customers;
            }
        }
        #endregion

    }
}
