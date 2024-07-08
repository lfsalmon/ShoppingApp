using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShopServer.Data.Data;
using ShopServer.Entity;
using ShopServer.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Data.Repositories
{
    public class UserRepostiory : IUserRepostiory
    {
        private readonly DbContextOptionsBuilder<ShopContex> _shopContext;
        private readonly ILogger<UserRepostiory> _logger;

        public UserRepostiory(ILogger<UserRepostiory> logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shopContext = new DbContextOptionsBuilder<ShopContex>();
            _shopContext.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<User> GetUserByUsername(string username)
        {
            User _result = null;
            try
            {
                using (var context = new ShopContex(_shopContext.Options))
                {
                    _result= await context.Users.SingleOrDefaultAsync(x=>x.Username== username);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error when try to get user  {username} {ex.Message}");
                throw ex;
            }
            return _result;
        }

        public async Task<User> Sigin(User _entity)
        {
            try
            {
                  using (var context = new ShopContex(_shopContext.Options))
                {
                    context.Users.Add(_entity);
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
    }
}
