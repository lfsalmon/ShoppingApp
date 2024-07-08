using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopServer.Business.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IEnumerable<AddressDto> Address { get; set; }
        public IEnumerable<ShoppingCarDto> ShoppingCars { get; set; }

        public CustomerDto(Customer _entity)
        {
            Id= _entity.Id;
            Name = _entity.Name;
            LastName = _entity.LastName;
            Address=_entity.Address.Select(x=>new AddressDto(x)).ToList();
            ShoppingCars = _entity.ShoppingCars?.Select(x => new ShoppingCarDto(x)).ToList();
        }
    }
}
