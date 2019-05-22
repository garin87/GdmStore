using GdmStore.Models;
using GdmStore.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GgmStore.Tests
{
    class BaseServiceFake : IBaseServices<Product>
    {
        private readonly List<Product> _product;

        public BaseServiceFake()
        {
            _product = new List<Product>
            {
               new Product { Id = 1, Name="Шток хромированный", Number= "50-E-1", Manufacturer = "HonBar",
                   Amount =6.04, PrimeCostEUR = 34.65, ProductTypeId=1},
               new Product { Id = 2, Name="Шток хромированный", Number="50-V2-1", Manufacturer = "HonBar",
                   Amount =6.84, PrimeCostEUR = 39.87, ProductTypeId=1},
               new Product { Id = 3, Name="Труба хонингованная", Number="80*95-E-4", Manufacturer = "HonBar",
                   Amount =7.24, PrimeCostEUR = 25.85, ProductTypeId=2}
            };

        }

        public IEnumerable<Product> GetAll()
        {
            return _product;
        }

        public async Task<Product> GetItem(int id)
        {
            return  _product.Where(a => a.Id == id)
            .FirstOrDefault();
        }

        public async Task<Product> DeleteItem(int id)
        {
            var temp =  _product.First(a => a.Id == id);
             _product.Remove(temp);

            return temp;
        }

        public async Task<Product> AddItem(Product product)
        {
            _product.Add(product);
          //  await _product.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateItem(Product product)

        {    Product p = await GetItem(product.Id);
             p.Name = product.Name;
             p.Number = product.Number;
             p.Amount = product.Amount;
             p.PrimeCostEUR = product.PrimeCostEUR;
             p.ProductTypeId = product.ProductTypeId;
            //_product.Update(product);
            //await _product.SaveChangesAsync();

            return product;
        }


    }
}
