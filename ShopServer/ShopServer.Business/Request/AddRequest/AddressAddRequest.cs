using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ShopServer.Business.Request.AddRequest
{
    public class AddressAddRequest
    {
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int Numeber { get; set; }
        public int? InternalNumber { get; set; }
        public Address GetEntity()
        {
            return new Address()
            {
                State = State,
                City = City,
                Street = Street,
                PostalCode = PostalCode,
                Numeber = Numeber,
                InternalNumber = InternalNumber
            };
        }
    }
}
