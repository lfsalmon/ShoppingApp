using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ShopServer.Business.Request.AddRequest
{
    public class StoreAddRequest
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int Numeber { get; set; }
        public int? InternalNumber { get; set; }
        public Store GetEntity()
        {
            return new Store()
            {
                Name = Name,
                State = State,
                City = City,
                Street = Street,
                PostalCode = PostalCode,
                InternalNumber = InternalNumber,
                Numeber= Numeber
            };
        }
    }
}
