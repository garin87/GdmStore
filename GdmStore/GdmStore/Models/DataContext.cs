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
               .WithMany(e => e.Products).OnDelete(DeleteBehavior.Restrict);
               //.HasForeignKey<int>(c => c.ProductTypeId);

            modelBuilder.Entity<Parameter>()
               .HasOne(Pr => Pr.ProductType)
               .WithMany(Pt => Pt.Parameters).OnDelete(DeleteBehavior.Restrict);
               //.HasForeignKey<int>(Pr => Pr.ProductTypeId);

            modelBuilder.Entity<ProductParameter>()
                .HasOne<Product>(bc => bc.Product)
                .WithMany(b => b.ProductParameters).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductParameter>()
                .HasOne<Parameter>(bc => bc.Parameter)
                .WithMany(c => c.ProductParameters).OnDelete(DeleteBehavior.Restrict);
           
            modelBuilder.Entity<ProductType>().HasData(
              new ProductType[]
              {
               new ProductType { ProductTypeId=1, NameType="Шток хромированный"},
              new ProductType { ProductTypeId=2, NameType="Труба хонингованная"}
              });

            modelBuilder.Entity<Parameter>().HasData(
             new Parameter[]
             {
               new Parameter { ParameterId=1, ProductTypeId=2, Name="Тип трубы"},
               new Parameter { ParameterId=2, ProductTypeId=1, Name="Тип штока"},
               new Parameter { ParameterId=3, ProductTypeId=1, Name="Марка стали"},
               new Parameter { ParameterId=4, ProductTypeId=1, Name="Диаметр"}
             });

            modelBuilder.Entity<Product>().HasData(
            new Product[]
          {
               new Product { ProductId=1, Name="Шток хромированный", Number= "50-E-1",
                   Amount =6.04, PrimeCostEUR = 34.65, ProductTypeId=1},
               new Product { ProductId=2, Name="Шток хромированный", Number="50-V2-1",
                   Amount =6.84, PrimeCostEUR = 39.87, ProductTypeId=1},
               new Product { ProductId=3, Name="Труба хонингованная", Number="80*95-E-4",
                   Amount =7.24, PrimeCostEUR = 25.85, ProductTypeId=2}
          });
           
           modelBuilder.Entity<ProductParameter>().HasData(
            new ProductParameter[]
        {
              new ProductParameter { ProductParameterId=1, ParameterId=2, ProductId=2, Value="H9" },
              new ProductParameter { ProductParameterId=2, ParameterId=1, ProductId=1, Value="Обычный" },
              new ProductParameter { ProductParameterId=3, ParameterId=3, ProductId=1, Value="CK45" },
              new ProductParameter { ProductParameterId=4, ParameterId=4, ProductId=1, Value="40" },
              new ProductParameter { ProductParameterId=5, ParameterId=4, ProductId=2, Value="50" },
              new ProductParameter { ProductParameterId=6, ParameterId=4, ProductId=3, Value="80*95" }
        });

        

            base.OnModelCreating(modelBuilder);
        }

        internal Product FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}

      
    
   


