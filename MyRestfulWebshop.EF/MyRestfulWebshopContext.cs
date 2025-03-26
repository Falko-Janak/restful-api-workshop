using Microsoft.EntityFrameworkCore;
using MyRestfulWebshop.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyRestfulWebshop.EF
{
    public class MyRestfulWebshopContext : DbContext
    {
        public MyRestfulWebshopContext(DbContextOptions<MyRestfulWebshopContext> options)
            : base(options)
        {
        }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<CartItem> CartItems { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CartItem>()
            //    .HasKey(ci => ci.Id);

            //modelBuilder.Entity<CartItem>()
            //    .HasOne(ci => ci.Cart)
            //    .WithMany(c => c.Items)
            //    .HasForeignKey(ci => ci.CartId);

            //modelBuilder.Entity<CartItem>()
            //    .HasOne(ci => ci.Product)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
