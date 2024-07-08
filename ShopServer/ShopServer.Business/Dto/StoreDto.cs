using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Business.Dto
{
    public class StoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string FullAddress { get; }
        public IEnumerable<ItemDto> Items { get; set; }
        public StoreDto(Store _entity)
        {
            Id = _entity.Id;
            Name = _entity.Name;
            State = _entity.State;
            City = _entity.City;
            var internalnumber = _entity.InternalNumber.HasValue ? $"{_entity.InternalNumber.Value} , " : "";
            FullAddress = $"{_entity.Street}. {_entity.Numeber},{internalnumber}{_entity.PostalCode}.";
        }
    }
}
