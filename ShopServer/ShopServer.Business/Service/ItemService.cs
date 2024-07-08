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
    public class ItemService : IItemService
    {

        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<ItemDto> Add(ItemAddRequest _request) => new ItemDto(await _repository.Add(_request.GetEntity()));

        public async Task<ItemDto> Delete(int id) => new ItemDto(await _repository.Delete(id));

        public async Task<List<ItemDto>> GetAll() => (await _repository.GetAll()).Select(x => new ItemDto(x)).ToList();

        public async Task<List<ItemDto>> GetByShop(int _shop_id) => (await _repository.GetByShop(_shop_id)).Select(x => new ItemDto(x)).ToList();

        public async Task<ItemDto> GetItem(int id) => new ItemDto(await _repository.GetById(id));

        public async Task<ItemDto> Update(ItemUpdateRequest _request) => new ItemDto(await _repository.Update(_request.GetEntity()));
    }
}
