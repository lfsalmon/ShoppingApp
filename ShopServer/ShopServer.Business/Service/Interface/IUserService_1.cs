using ShopServer.Business.Dto;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Business.Request.UpdateRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Business.Service.Interface
{
    public interface IItemService
    {
        public Task<ItemDto> GetItem(int id);
        public Task<ItemDto> Add(ItemAddRequest _request);
        public Task<ItemDto> Update(ItemUpdateRequest _request);
        public Task<ItemDto> Delete(int id);
        public Task<List<ItemDto>> GetAll();

        public Task<List<ItemDto>> GetByShop(int _shop_id);
    }
}
