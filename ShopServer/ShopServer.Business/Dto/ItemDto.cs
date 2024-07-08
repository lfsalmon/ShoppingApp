using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Business.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public int StoreId { get; set; }
        public StoreDto Store { get; set; }
        public ItemDto(Item _entity) 
        {
            Id = _entity.Id;
            Code = _entity.Code;
            Name = _entity.Name;
            Description = _entity.Description;
            Cost = _entity.Cost;
            Stock = _entity.Stock;
            Image = _entity.Image;
            StoreId = _entity.StoreId;
            if(_entity.Store!= null) 
                Store =new StoreDto(_entity.Store);
        }
    }
}
