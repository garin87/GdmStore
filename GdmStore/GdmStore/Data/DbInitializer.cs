using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GdmStore.Models;

namespace GdmStore.Data
{
    public class DbInitializer
    {

        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.ProductTypes.Any())
            {
                return;   
            }

            var productTypes = new ProductType[]
             {
               new ProductType {  NameType="Шток хромированный"},
              new ProductType { NameType="Труба хонингованная"}
             };

            foreach (ProductType s in productTypes)
            {
                context.ProductTypes.Add(s);
            }
            context.SaveChanges();

            var parameters = new Parameter[]
             {
               new Parameter { ProductTypeId=2, Name="Тип трубы"},
               new Parameter { ProductTypeId=1, Name="Тип штока"},
               new Parameter { ProductTypeId=1, Name="Марка стали"},
               new Parameter { ProductTypeId=1, Name="Диаметр"}
             };

            foreach (Parameter c in parameters)
            {
                context.Parameters.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
          {
               new Product {  Name="Шток хромированный", Number= "50-E-1",
                   Amount =6.04, PrimeCostEUR = 34.65, ProductTypeId=1},
               new Product {  Name="Шток хромированный", Number="50-V2-1",
                   Amount =6.84, PrimeCostEUR = 39.87, ProductTypeId=1},
               new Product {  Name="Труба хонингованная", Number="80*95-E-4",
                   Amount =7.24, PrimeCostEUR = 25.85, ProductTypeId=2}
          };

            foreach (Product e in products)
            {
                context.Products.Add(e);
            }
            context.SaveChanges();

            var productParameters = new ProductParameter[]
             {
              new ProductParameter {  ParameterId=2, ProductId=2, Value="H9" },
              new ProductParameter {  ParameterId=1, ProductId=1, Value="Обычный" },
              new ProductParameter {  ParameterId=3, ProductId=1, Value="CK45" },
              new ProductParameter {  ParameterId=4, ProductId=1, Value="40" },
              new ProductParameter {  ParameterId=4, ProductId=2, Value="50" },
              new ProductParameter {  ParameterId=4, ProductId=3, Value="80*95" }
            };

            foreach (ProductParameter e in productParameters)
            {
                context.ProductParameters.Add(e);
            }
            context.SaveChanges();

        }
    }
}
