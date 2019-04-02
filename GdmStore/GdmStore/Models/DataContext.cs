using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GdmStore.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        //public DbSet<BaseObject> BaseObjects { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<ProductParameter> ProductParameters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
               .HasOne(c => c.ProductType)
               .WithMany(e => e.Products)
               .HasForeignKey(c => c.ProductTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Parameter>()
               .HasOne(Pr => Pr.ProductType)
               .WithMany(Pt => Pt.Parameters)
               .HasForeignKey(Pr => Pr.ProductTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductParameter>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductParameters)
                 .HasForeignKey("ProductId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductParameter>()
                .HasOne(bc => bc.Parameter)
                .WithMany(c => c.ProductParameters)
                .HasForeignKey("ParameterId")
                .OnDelete(DeleteBehavior.Restrict);
      
            base.OnModelCreating(modelBuilder);
        }
        
        internal Product FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}

      
    
   


