using ShopServer.Business.Dto;
using ShopServer.Business.Request.AddRequest;
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
    public class ShoppingCarService : IShoppingCarService
    {
        private readonly IShoppingCarRepository _repository;

        public ShoppingCarService(IShoppingCarRepository repository)
        {
            _repository = repository;
        }

        public async Task<ShoppingCarDto> Add(ShoppingCarAddRequest _request)
        {
            ShoppingCarDto result=null;
            var current_shoppingcar=await _repository.GetByClient(_request.CustomerId);


            if (current_shoppingcar == null) result=new ShoppingCarDto(await _repository.Add(_request.GetEntity()));
            else
            {
                var curretn_item= current_shoppingcar.FirstOrDefault(x=>x.ItemId== _request.ItemId);
                if(curretn_item == null) result = new ShoppingCarDto(await _repository.Add(_request.GetEntity()));
                else
                {
                    curretn_item.Count++;
                    result = new ShoppingCarDto(await _repository.Update(curretn_item));
                }
                
            }
            return result;

        }
        public async Task<ShoppingCarDto> Delete(ShoppingCarAddRequest _request)
        {
            ShoppingCarDto result = null;
            var current_shoppingcar = await _repository.GetByClient(_request.CustomerId);


            if (current_shoppingcar != null) 
            {
                var curretn_item = current_shoppingcar.FirstOrDefault(x => x.ItemId == _request.ItemId);
                if (curretn_item != null)
                {
                    curretn_item.Count--;
                    if(curretn_item.Count<=0)
                        result = new ShoppingCarDto(await _repository.Delete(curretn_item.Id));
                    else
                        result = new ShoppingCarDto(await _repository.Update(curretn_item));
                }

            }
            return result;
        }

        public async Task<ShoppingCarDto> DeleteAll(int _id)=>new ShoppingCarDto(await _repository.Delete(_id));

        public async Task<List<ShoppingCarDto>> GetByClient(int _customer_id) => (await _repository.GetByClient(_customer_id)).Select(x => new ShoppingCarDto(x)).ToList();
       
    }
}
