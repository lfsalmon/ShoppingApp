using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopServer.Business.Request.AddRequest
{
    public class CustomerAddRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public IEnumerable<AddressAddRequest> Address { get; set; }

        public Customer GetEntity()
        {
            return new Customer()
            {
                Name = Name,
                LastName = LastName,
                Address = Address?.Select(x=>x.GetEntity())
            };
        }
    }
}
