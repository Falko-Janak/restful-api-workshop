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
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Konfiguration der Viele-zu-Viele Beziehung zwischen Cart und Product
        //    modelBuilder.Entity<Cart>()
        //        .HasMany(c => c.Products)
        //        .WithMany();

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
