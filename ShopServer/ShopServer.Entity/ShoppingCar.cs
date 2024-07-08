using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Entity
{
    public class ShoppingCar
    {
        public int Id { get; set; }
        public int CustomerId {  get; set; }
        public Customer Customer { get; set; }
        public int ItemId { get; set; }
        public Item Item { get;set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
