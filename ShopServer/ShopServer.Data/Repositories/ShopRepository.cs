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
    public class ShopRepository : IGenericRepository<Store>
    {
        private readonly DbContextOptionsBuilder<ShopContex> _shopContext;
        private readonly ILogger<CustomerRepository> _logger;

        public ShopRepository(ILogger<CustomerRepository> logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shopContext = new DbContextOptionsBuilder<ShopContex>();
            _shopContext.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Store> Add(Store _entity)
        {
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    context.Store.Add(_entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to update customer with {_entity.Id} {ex.Message}");
                throw ex;
            }
            return _entity;
        }

        public async Task<Store> Delete(int _id)
        {
            Store _current_shop = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _current_shop = context.Store.FirstOrDefault(i => i.Id == _id);
                    if (_current_shop != null)
                    {
                        context.Store.Remove(_current_shop);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to delete customer {_id} {ex.Message}");
                throw ex;
            }
            return _current_shop;
        }



        public async Task<List<Store>> GetAll()
        {
            List<Store> _shop_list = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _shop_list = context.Store.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to ger all customers {ex.Message}");
                throw ex;
            }
            return _shop_list;
        }

        public async Task<Store> GetById(int _id)
        {
            Store _shop_list = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _shop_list = context.Store.FirstOrDefault(x => x.Id == _id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to ger all customers {ex.Message}");
                throw ex;
            }
            return _shop_list;
        }

        public async Task<Store> Update(Store _entity)
        {
            Store _current_shop= null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _current_shop = context.Store.FirstOrDefault(i => i.Id == _entity.Id);
                    if (_current_shop != null)
                    {
                        context.Store.Update(_entity);
                        context.SaveChanges();
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
