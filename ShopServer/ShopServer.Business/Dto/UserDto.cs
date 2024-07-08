using ShopServer.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Business.Dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public CustomerDto Customer { get; set; }
        public StoreDto Store { get; set; }
        public string Token { get; set; }
    }
}
