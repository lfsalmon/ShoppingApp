using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopServer.Business.Dto;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Business.Service.Interface;
using ShopServer.Data.Repositories;
using ShopServer.Entity;
using ShopServer.Entity.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Business.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepostiory _repository;
        private readonly ICustomerService _customerService;
        private readonly IStoreService _storeService;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepostiory repository, ICustomerService customerservice, IStoreService storeservice, IConfiguration configuration)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _customerService = customerservice ?? throw new ArgumentNullException(nameof(customerservice));
            _storeService = storeservice ?? throw new ArgumentNullException(nameof(storeservice));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<UserDto> Login(UserLoginRequest _user)
        {
            UserDto resutl = null;
            var _userInDb=await _repository.GetUserByUsername(_user.Username);
            if (_userInDb == null) 
                return resutl;

            resutl = new UserDto()
            {
                Username = _userInDb.Username,
                Email = _userInDb.Email,
                Role = _userInDb.Role,
            };

            if (_userInDb.Password.Equals(_user.Password))
            {
                if (resutl.Role == Role.Customer) resutl.Customer = await _customerService.GetCustomer(_userInDb.Shop_UserId.Value);
                else if (resutl.Role == Role.Store) resutl.Store = await _storeService.GetShop(_userInDb.Shop_UserId.Value);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, _userInDb.Username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                resutl.Token = tokenString;
            }
            return resutl;

        }

        public async Task<UserDto> Sigin(UserSignupRequest _user)
        {
            UserDto resutl = null;
            var _userInDb = await _repository.GetUserByUsername(_user.Username);
            if (_userInDb != null)
                return resutl;

            _userInDb = _user.GetEntity();
            resutl = new UserDto()
            {
                Username = _user.Username,
                Email = _user.Email,
                Role = _user.Role,
            };
            if (resutl.Role == Role.Customer)
            {
                resutl.Customer = await _customerService.Add(_user.Customer);
                _userInDb.Shop_UserId = resutl.Customer.Id;
            }
            else if (resutl.Role == Role.Store)
            {
                resutl.Store = await _storeService.Add(_user.Store);
                _userInDb.Shop_UserId = resutl.Store.Id;
            }
            await _repository.Sigin(_userInDb);
            return resutl;
        }
    }
}
