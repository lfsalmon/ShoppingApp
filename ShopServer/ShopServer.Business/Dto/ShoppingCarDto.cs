using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Business.Dto
{
    public class ShoppingCarDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ItemId { get; set; }
        public ItemDto Item { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }

        public ShoppingCarDto(ShoppingCar _entity)
        {
            Id = _entity.Id;
            CustomerId = _entity.CustomerId;
            ItemId = _entity.ItemId;
            Item = (_entity.Item != null)? new ItemDto(_entity.Item):null;
            Date = _entity.Date;
            Count = _entity.Count;
        }
    }
}
