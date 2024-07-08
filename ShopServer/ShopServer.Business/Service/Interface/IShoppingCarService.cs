using ShopServer.Business.Dto;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Business.Service.Interface
{
    public interface IShoppingCarService
    {
       
        public Task<ShoppingCarDto> Add(ShoppingCarAddRequest _request);
        public Task<ShoppingCarDto> Delete(ShoppingCarAddRequest _request);
        public Task<ShoppingCarDto> DeleteAll(int _id);
        public Task<List<ShoppingCarDto>> GetByClient(int _customer_id);
    }
}
