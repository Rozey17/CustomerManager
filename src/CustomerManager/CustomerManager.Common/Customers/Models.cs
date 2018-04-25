using System;

namespace CustomerManager.Common.Data.Models
{
    public class CustomerTypeModel
    {
        public CustomerTypeModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
