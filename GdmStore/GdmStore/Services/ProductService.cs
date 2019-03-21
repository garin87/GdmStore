using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GdmStore.Models;
using GdmStore.DTO;



namespace GdmStore.Services
{    
    public class ProductService //: BaseService<Product>
    {
        private readonly DataContext _context;
       
        public ProductService(DataContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Product> GetAll()
        {
           return _context.Products.ToList();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddProduct(Product product)
        {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            Product p = await GetProduct(product.ProductId);
            p.Name = product.Name;
            p.Number = product.Number;
            p.Amount = product.Amount;
            p.PrimeCostEUR = product.PrimeCostEUR;
            p.ProductTypeId = product.ProductTypeId;
            p.ProductParameters = product.ProductParameters;
            await _context.SaveChangesAsync();
            return  product;
        }

        public async Task<IList<Product>> TestProducts(int ProductTypeId)
        {
            return await _context.Products.Include(p => p.ProductType)
                                .Where(p => p.ProductTypeId == ProductTypeId)
                                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts(int id)
        {
            var items = await _context.Products
                             .SelectMany(p => p.ProductParameters)
                             .Select(pp => new ProductDTO
                             {
                                 ProductId = pp.ProductId,
                                 Number = pp.Product.Number,
                                 Amount = pp.Product.Amount,
                                 PrimeCostEUR = pp.Product.PrimeCostEUR,
                                 NameType = pp.Product.ProductType.NameType,
                                 ProductTypeId = pp.Product.ProductTypeId,
                                 Name = pp.Parameter.Name,
                                 Value = pp.Value
                             })
                            .Where(pp => pp.ProductTypeId == id)
                            .ToListAsync();
            return items;
        }

        /*
        public async Task<Product> AddProducts(Product product..)
        {
            Product dbEntry = _context.Products.Find(product.ProductId);
            ProductType dbEntrytype = _context.ProductTypes.Find(productType.ProductTypeId);
            Parameter dbEntryParam = _context.Parameters.Find(parameter.ParameterId);
            ProductParameter dbEntryPP = _context.ProductParameters.Find(ProductParameter.ProductParameterId);

            if (dbEntry != null && dbEntrytype != null &&
                dbEntryParam != null && dbEntryPP != null)
            {
                dbEntry.ProductId = product.ProductId;
                dbEntry.Number = product.Number;
                dbEntry.Amount = product.Amount;
                dbEntry.PrimeCostEUR = product.PrimeCostEUR;
                dbEntrytype.NameType = productType.NameType;
                dbEntryParam.Name = parameter.Name;
                dbEntryPP.Value = ProductParameter.Value;
            }
           // _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        */
        /*
                 public async Task<IEnumerable<ProductDTO>> GetProducts(int id)
        {   

            var items = await _context.Products
                             .Select(p => new ProductDTO
                             {
                                      ProductId = p.ProductId,
                                      Number = p.Number,
                                      Amount = p.Amount,
                                      PrimeCostEUR = p.PrimeCostEUR,
                                      NameType = p.ProductType.NameType,
                                      ProductTypeId = p.ProductTypeId
                             })
                             .Where(p => p.ProductTypeId == id)
                             .ToListAsync();
            return items;
        }
   
       */
    }
}
