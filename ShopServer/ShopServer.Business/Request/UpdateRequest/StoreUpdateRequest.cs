using ShopServer.Business.Request.AddRequest;
using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Business.Request.UpdateRequest
{
    public class StoreUpdateRequest:StoreAddRequest
    {
        public int Id { get; set; }
        public Store UpdateEntity()
        {
            var _entity=GetEntity();
            _entity.Id = Id;
            return _entity;
        }
    }
}
