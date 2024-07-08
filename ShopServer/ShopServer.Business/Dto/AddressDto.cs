using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Business.Dto
{
    public class AddressDto
    {
        public string State { get; set; }
        public string City { get; set; }
        public string FullAddress { get; }
        public AddressDto(Address _entity) 
        {
            State = _entity.State;
            City = _entity.City;
            var internalnumber = _entity.InternalNumber.HasValue ? $"{_entity.InternalNumber.Value} , " : "";
            FullAddress = $"{_entity.Street}. {_entity.Numeber},{internalnumber}{_entity.PostalCode}.";
        }
    }
}
