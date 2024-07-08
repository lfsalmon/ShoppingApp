﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Entity
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int Numeber { get; set; }
        public int? InternalNumber { get; set; }
        public IEnumerable<Item> Items { get; set; }

    }
}
