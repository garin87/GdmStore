using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GdmStore.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GdmStore.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<ProductParameter> ProductParameters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
             .HasOne(c => c.Role)
             .WithMany(e => e.User)
             .HasForeignKey(c => c.RoleId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
               .HasOne(c => c.ProductType)
               .WithMany(e => e.Products)
               .HasForeignKey(c => c.ProductTypeId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Parameter>()
               .HasOne(Pr => Pr.ProductType)
               .WithMany(Pt => Pt.Parameters)
               .HasForeignKey(Pr => Pr.ProductTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductParameter>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductParameters)
                 .HasForeignKey("ProductId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductParameter>()
                .HasOne(bc => bc.Parameter)
                .WithMany(c => c.ProductParameters)
                 .HasForeignKey("ParameterId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderProduct>()
              .HasOne(bc => bc.Order)
              .WithMany(b => b.OrderProduct)
               .HasForeignKey("OrderId")
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderProduct>()
               .HasOne(bc => bc.Product)
               .WithMany(c => c.OrderProduct)
                .HasForeignKey("ProductId")
               .OnDelete(DeleteBehavior.Cascade);

            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "12345";

            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });

            base.OnModelCreating(modelBuilder);
        }

        internal Product FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

    }
}
