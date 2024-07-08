using ShopServer.Business.Dto;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Business.Request.UpdateRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Business.Service.Interface
{
    public interface IStoreService
    {
        public Task<StoreDto> GetShop(int id);
        public Task<StoreDto> Add(StoreAddRequest _request);
        public Task<StoreDto> Update(StoreUpdateRequest _request);
        public Task<StoreDto> Delete(int id);
        public Task<List<StoreDto>> GetAll();


    }
}
