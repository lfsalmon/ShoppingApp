using ShopServer.Entity;
using ShopServer.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ShopServer.Business.Request.AddRequest
{
    public class UserSignupRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public CustomerAddRequest Customer { get; set; }
        public StoreAddRequest Store { get; set; }

        public User GetEntity()
        {
            return new User()
            {
               Email = Email,
               Password = Password,
               Username = Username,
               Role = Role
               
            };
        }

    }
}
