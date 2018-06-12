using CustomerManager.Common.Data.Models;
using CustomerManager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.BusinessLogic
{
    public class CustomerTypeEngine
    {
        // We create a 
        private readonly CustomerTypeRepository _repository;

        // Anytime we would create a CustomerTypeEngine object 
        // it would create an instance of the CustomerTypeRepository class
        public CustomerTypeEngine()
        {
            _repository = new CustomerTypeRepository();
        }
        
        public Task<bool> InsertAsync(CustomerTypeModel model)
        {
            return _repository.InsertAsync(model);
        }

        public Task<IEnumerable<CustomerTypeModel>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            return _repository.DeleteAsync(id);
        }
    }
}
