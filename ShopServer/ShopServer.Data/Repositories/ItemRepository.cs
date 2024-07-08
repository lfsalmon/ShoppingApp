using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShopServer.Data.Data;
using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Data.Repositories
{
    public class ItemRepository: IItemRepository
    {
        private readonly DbContextOptionsBuilder<ShopContex> _shopContext;
        private readonly ILogger<ItemRepository> _logger;

        public ItemRepository(ILogger<ItemRepository> logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shopContext = new DbContextOptionsBuilder<ShopContex>();
            _shopContext.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Item> Add(Item _entity)
        {
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    context.Items.Add(_entity);
                    context.SaveChanges();
                    return await GetById(_entity.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to update customer with {_entity.Id} {ex.Message}");
                throw ex;
            }
            return _entity;
        }

        public async Task<Item> Delete(int _id)
        {
            Item _current_item = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _current_item = context.Items.FirstOrDefault(i => i.Id == _id);
                    if (_current_item != null)
                    {
                        context.Items.Remove(_current_item);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to delete customer {_id} {ex.Message}");
                throw ex;
            }
            return _current_item;
        }



        public async Task<List<Item>> GetAll()
        {
            List<Item> _item_list = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _item_list = context.Items.Include(x => x.Store).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to ger all customers {ex.Message}");
                throw ex;
            }
            return _item_list;
        }

        public async Task<Item> GetById(int _id)
        {
            Item _item = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _item = context.Items.Include(x=>x.Store).FirstOrDefault(x => x.Id == _id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to ger all customers {ex.Message}");
                throw ex;
            }
            return _item;
        }

        public async Task<List<Item>> GetByShop(int _shop_id)
        {
            List<Item> _item_list = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _item_list = context.Items.Include(x => x.Store).Where(x=>x.StoreId== _shop_id).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to ger all customers {ex.Message}");
                throw ex;
            }
            return _item_list;
        }

        public async Task<Item> Update(Item _entity)
        {
            Item _current_item = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _current_item = context.Items.FirstOrDefault(i => i.Id == _entity.Id);
                    if (_current_item != null)
                    {
                        context.Items.Update(_entity);
                        context.SaveChanges();
                        return await GetById(_entity.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to update customer with {_entity.Id} {ex.Message}");
                throw ex;
            }
            return _entity;
        }
    }
}

