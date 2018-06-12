using System;

namespace CustomerManager.Common.Data.Models
{
    public class CustomerTypeModel
    {
        #region
        public CustomerTypeModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion

        public Guid Id { get; }
        public string Name { get; }
    }
}
