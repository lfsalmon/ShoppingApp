using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Business.Request.AddRequest
{
    public class ItemAddRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public int StoreId { get; set; }
        public Item GetEntity() 
        {
            return new Item()
            {
                Code = Code,
                Cost = Cost,
                Stock = Stock,
                Name = Name,
                Description = Description,
                Image = Image,
                StoreId = StoreId
            };
        }
    }
}
