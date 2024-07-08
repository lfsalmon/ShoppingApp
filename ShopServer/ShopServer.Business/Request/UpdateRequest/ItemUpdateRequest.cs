using ShopServer.Business.Request.AddRequest;
using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Business.Request.UpdateRequest
{
    public class ItemUpdateRequest : ItemAddRequest
    {
        public int Id { get; set; }
        public Item UpdateEntity()
        {
            var _entity = GetEntity();
            _entity.Id = Id;
            return _entity;
        }
    }
}
