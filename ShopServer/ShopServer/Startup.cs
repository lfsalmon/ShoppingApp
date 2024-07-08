using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopServer.Api.Data;
using ShopServer.Business.Service.Interface;
using ShopServer.Business.Service;
using ShopServer.Data.Data;
using ShopServer.Data.Repositories;
using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopServer.API.Hubs;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ShopServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Shop
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IGenericRepository<Store>, ShopRepository>();
            //Item
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IItemRepository, ItemRepository>();
            //Customer
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IGenericRepository<Customer>, CustomerRepository>();
            // ShoppingCar
            services.AddTransient<IShoppingCarService, ShoppingCarService>();
            services.AddTransient<IShoppingCarRepository, ShoppingCarRepository>();

            // ShoppingCar
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepostiory, UserRepostiory>();

            services.AddSignalR();
            var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.SetIsOriginAllowed(origin=>true)
                                        .AllowAnyHeader() 
                                        .AllowAnyMethod()
                                        );
            });

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShopContex>(options =>
                
                 options.UseSqlServer(
                     connection,
                     sqlOptions => sqlOptions.MigrationsAssembly("ShopServer.API"))

                 );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Shop API",
                    Description = "This is a Shop api"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
           
            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<Messages>("hub");
            });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop API V1");
                c.RoutePrefix = string.Empty; 
            });
            try
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    Console.WriteLine($"Satarting Migration of {nameof(ShopContex)}...");
                    var context = serviceScope.ServiceProvider.GetRequiredService<ShopContex>();
                    context.Database.Migrate();
                    Console.WriteLine("Finish Migration");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

           
        }
       

    }
}
