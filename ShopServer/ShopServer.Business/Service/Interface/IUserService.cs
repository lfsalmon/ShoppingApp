using ShopServer.Business.Dto;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Business.Service.Interface
{
    public interface IUserService
    {
        Task<UserDto> Login(UserLoginRequest _user);
        Task<UserDto> Sigin(UserSignupRequest _user);
    }
}
