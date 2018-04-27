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
        private readonly CustomerTypeRepository _repository;

        public CustomerTypeEngine()
        {
            _repository = new CustomerTypeRepository();
        }

        public bool Insert(CustomerTypeModel model)
        {
            return _repository.Insert(model);
        }

        public IEnumerable<CustomerTypeModel> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
