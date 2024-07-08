using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ShopServer.Data.Data;
using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Api.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShopContex>
    {

        public ShopContex CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopContex>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Shop;User Id=sa;Password=psw101425;");

            return new ShopContex(optionsBuilder.Options);
        }
    }
}
