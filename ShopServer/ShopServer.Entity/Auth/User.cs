using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Entity.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public int? Shop_UserId { get; set; }

    }
}
