using Microsoft.EntityFrameworkCore;
using ShopServer.Entity;
using ShopServer.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopServer.Data.Data
{
    public class ShopContex: DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<ShoppingCar> ShoppingCars { get; set;}
        public DbSet<User> Users{ get; set; }

        public ShopContex(DbContextOptions<ShopContex> options): base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Adresses");
                entity.HasKey(k => k.Id);
                entity.HasOne(a=>a.Customer)
                        .WithMany(a=>a.Address)
                        .HasForeignKey(a=>a.CustomerId)
                        .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(k => k.Id);

            });
            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items");
                entity.HasKey(k => k.Id);
                entity.HasOne(s=>s.Store)
                        .WithMany(s=>s.Items)
                        .HasForeignKey(s=>s.StoreId)
                        .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");
                entity.HasKey(k => k.Id);
            });
            modelBuilder.Entity<ShoppingCar>(entity =>
            {
                entity.ToTable("ShoppingCars");
                
                entity.HasKey(k => k.Id);

                entity.HasOne(s => s.Customer)
                      .WithMany(s => s.ShoppingCars)
                      .HasForeignKey(s => s.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Item)
                      .WithMany(s => s.ShoppingCars)
                      .HasForeignKey(s => s.ItemId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(k => k.Id);
            });

        }
    }
}
