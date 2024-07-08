using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Data.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        public Task<List<Item>> GetByShop(int _shop_id);
    }
}
