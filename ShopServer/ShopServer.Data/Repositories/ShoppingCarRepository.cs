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
    public class ShoppingCarRepository : IShoppingCarRepository
    {
        private readonly DbContextOptionsBuilder<ShopContex> _shopContext;
        private readonly ILogger<ShoppingCarRepository> _logger;

        public ShoppingCarRepository(ILogger<ShoppingCarRepository> logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shopContext = new DbContextOptionsBuilder<ShopContex>();
            _shopContext.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<ShoppingCar> Add(ShoppingCar _entity)
        {
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    context.ShoppingCars.Add(_entity);
                    context.SaveChanges();
                    //return context.ShoppingCars.AsNoTracking().Include(x=>x.Item).Include(y=>y.Customer).FirstOrDefault(X=>X.Id==_entity.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to update customer with {_entity.Id} {ex.Message}");
                throw ex;
            }
            return _entity;
        }

        public async Task<ShoppingCar> Delete(int _id)
        {
            ShoppingCar _current_item = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _current_item = context.ShoppingCars.FirstOrDefault(i => i.Id == _id);
                    if (_current_item != null)
                    {
                        context.ShoppingCars.Remove(_current_item);
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



        public async Task<List<ShoppingCar>> GetByClient(int _customer_id)
        {
            List<ShoppingCar> _item_list = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _item_list = context.ShoppingCars.AsNoTracking().Include(x=>x.Item).Where(x=>x.CustomerId== _customer_id).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to ger all customers {ex.Message}");
                throw ex;
            }
            return _item_list;
        }


        public async Task<ShoppingCar> Update(ShoppingCar _entity)
        {
            ShoppingCar _current_item = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    //_current_item = context.ShoppingCars.FirstOrDefault(i => i.Id == _entity.Id);
                    if (_entity != null)
                    {
                        context.ShoppingCars.Update(_entity);
                        context.SaveChanges();
                      //  return context.ShoppingCars.AsNoTracking().Include(x => x.Item).Include(y => y.Customer).FirstOrDefault(X => X.Id == _entity.Id);
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
