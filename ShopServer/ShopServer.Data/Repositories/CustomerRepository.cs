using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShopServer.Data.Data;
using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Data.Repositories
{
    public class CustomerRepository : IGenericRepository<Customer>
    {
        private readonly DbContextOptionsBuilder<ShopContex> _shopContext;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(ILogger<CustomerRepository> logger,IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shopContext = new DbContextOptionsBuilder<ShopContex>();
            _shopContext.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        }

        public async Task<Customer> Add(Customer _entity)
        {
           // Customer _current_customer = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    context.Customers.Add(_entity);
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

        public async Task<Customer> Delete(int _id)
        {
            Customer _current_customer=null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _current_customer = context.Customers.FirstOrDefault(i => i.Id == _id);
                    if (_current_customer != null)
                    {
                        context.Customers.Remove(_current_customer);
                        context.SaveChanges();  
                    }
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Some error when try to delete customer {_id} {ex.Message}");
                throw ex;
            }
            return _current_customer;

        }



        public async Task<List<Customer>> GetAll()
        {
            List<Customer> _customer_list= null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _customer_list = context.Customers.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to ger all customers {ex.Message}");
                throw ex;
            }
            return _customer_list;
        }

        public async Task<Customer> GetById(int _id)
        {
            Customer _customer_list = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _customer_list = context.Customers.Include(x => x.ShoppingCars).Include(x=>x.Address).FirstOrDefault(x=>x.Id==_id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to ger all customers {ex.Message}");
                throw ex;
            }
            return _customer_list;
        }

        public async Task<Customer> Update(Customer _entity)
        {
            Customer _current_customer = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _current_customer = context.Customers.FirstOrDefault(i => i.Id == _entity.Id);
                    if (_current_customer != null)
                    {
                        context.Customers.Update(_entity);
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
