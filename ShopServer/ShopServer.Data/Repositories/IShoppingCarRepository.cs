using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Data.Repositories
{
    public interface IShoppingCarRepository
    {
        public Task<ShoppingCar> Add(ShoppingCar _entity);
        public Task<ShoppingCar> Update(ShoppingCar _entity);
        public Task<ShoppingCar> Delete(int _id);
        public Task<List<ShoppingCar>> GetByClient(int _customer_id);
    }
}
