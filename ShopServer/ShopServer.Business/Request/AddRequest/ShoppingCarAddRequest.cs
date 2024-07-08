using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace ShopServer.Business.Request.AddRequest
{
    public class ShoppingCarAddRequest
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
       
        public DateTime Date { get; set; }

        public ShoppingCar GetEntity()
        {
            return new ShoppingCar()
            {
                CustomerId = CustomerId,
                ItemId = ItemId,
                Date = Date,
                Count = 1
            };
        }
    }
}
