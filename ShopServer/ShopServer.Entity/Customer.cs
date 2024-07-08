using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopServer.Entity
{
    public class Customer
    {
        public int Id { get;set; }
        public string Name { get;set; }
        public string LastName { get;set; }
        public IEnumerable<Address> Address{ get;set; }
        public IEnumerable<ShoppingCar> ShoppingCars { get; set; }
    }
}
