using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int Stock{ get; set; }
        public string Image { get; set; }
        public int StoreId { get; set; }
        public Store Store {get;set;}
        public IEnumerable<ShoppingCar> ShoppingCars { get; set; }
    }
}
