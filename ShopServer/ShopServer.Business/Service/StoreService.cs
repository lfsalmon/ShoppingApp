using ShopServer.Business.Dto;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Business.Request.UpdateRequest;
using ShopServer.Business.Service.Interface;
using ShopServer.Data.Repositories;
using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Business.Service
{
    public class StoreService : IStoreService
    {

        private readonly IGenericRepository<Store> _repository;

        public StoreService(IGenericRepository<Store> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<StoreDto> Add(StoreAddRequest _request)=> new StoreDto(await _repository.Add(_request.GetEntity()));
        
        public async Task<StoreDto> Delete(int id) => new StoreDto(await _repository.Delete(id));
        
        public async Task<List<StoreDto>> GetAll() => (await _repository.GetAll()).Select(x=>new StoreDto(x)).ToList();

        public async Task<StoreDto> GetShop(int id) => new StoreDto(await _repository.GetById(id));

        public async Task<StoreDto> Update(StoreUpdateRequest _request) => new StoreDto(await _repository.Update(_request.GetEntity()));
    }
}
