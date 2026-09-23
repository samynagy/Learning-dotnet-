using EFApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFApp
{
    internal class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstr =
                "Data Source=(localdb)\\ProjectModels;Initial Catalog=EFApp;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=True;" +
                "Trust Server Certificate=False;" +
                "Application Intent=ReadWrite;" +
                "Multi Subnet Failover=False;" +
                "Command Timeout=30";
            optionsBuilder.UseSqlServer(connectionstr);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// limit customer properties
            modelBuilder.Entity<Customer>()
                .Property(p => p.Name)
                .HasColumnType("varchar(50)");
            modelBuilder.Entity<Customer>()
                .Property(p => p.Email)
                .HasColumnType("varchar(50)");

            /// set primary key
            modelBuilder.Entity<CustomerProfile>()
                .HasKey(cp => cp.CustomerID);

            /// define one-to-one relationship
            modelBuilder.Entity<Customer>()
                .HasOne(cp => cp.customerProfile)
                .WithOne(c => c.Customer)
                 .HasForeignKey<CustomerProfile>(cp => cp.CustomerID);



            //// define one-to-many relateion ship

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            //// set value to column when created

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .HasDefaultValueSql("GETDATE()");

            /// one-to-many
            modelBuilder.Entity<Category>()
               .HasMany(c => c.Products)
               .WithOne(p => p.Category)
               .HasForeignKey(p => p.CategoryId);


            /// many-to-many repersented with another table OrderItmes ( Order => one-to-many => OrderItems)
                                                                  // ( Product => one-to-many => OrderItems)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderItems)
            .WithOne(oi => oi.Product)
            .HasForeignKey(oi => oi.ProductId)  ;

            /// composite primary key
            modelBuilder.Entity<OrderItem>()
               .HasKey(oi => new
               {
                   oi.OrderId,
                   oi.ProductId
               });

            //  Price

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(10,2)");



            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasColumnType("decimal(10,2)");

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerProfile> customerProfiles { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }




    }
}
