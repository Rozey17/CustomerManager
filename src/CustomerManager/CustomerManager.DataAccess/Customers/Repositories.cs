using CustomerManager.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;

namespace CustomerManager.DataAccess
{
    public class CustomerTypeRepository
    {
        private readonly string _connectionString;

        public CustomerTypeRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
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
