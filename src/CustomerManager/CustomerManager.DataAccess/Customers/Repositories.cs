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

        public bool Insert(CustomerTypeModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute("InsertCustomerType", model);

                return result > 0;
            }
        }

        public bool Delete(Guid name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var output = connection.Execute("dbo.DeleteCustomerType", new { Id = name });
                return output > 0;
            }
        }

        public IEnumerable<CustomerTypeModel> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var customers = connection.Query<CustomerTypeModel>("dbo.RetrieveCustomerTypes");

                return customers;
            }
        }
    }
}
