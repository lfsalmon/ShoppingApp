using ShopServer.Entity;
using ShopServer.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Data.Repositories
{
    public  interface IUserRepostiory
    {
        Task<User> GetUserByUsername(string username);
        Task<User> Sigin(User _entity);
    }
}
