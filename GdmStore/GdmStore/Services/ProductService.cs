using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GdmStore.Models;
using GdmStore.DTO;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

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
            Product product = _context.Products
              .Where(o => o.Id == id)
              .FirstOrDefault();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            Product p = await GetProduct(product.Id);
            p.Name = product.Name;
            p.Number = product.Number;
            p.Amount = product.Amount;
            p.PrimeCostEUR = product.PrimeCostEUR;
            p.ProductTypeId = product.ProductTypeId;
            p.ProductParameters = product.ProductParameters;
            await _context.SaveChangesAsync();
            return  product;
        }

        public async Task<IList<Product>> TestProducts(int id)
        {

            return await _context.Products.Include(p => p.ProductType)
                                .Where(p => p.ProductTypeId == id)
                              
                             .ToListAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts(int id)
        {
            var typeParams = await _context.Parameters.Where(t => t.ProductTypeId == id)
                                           .ToListAsync();

            var products = await _context.Products.Include(t => t.ProductParameters)
                                         .Include(h => h.ProductType)   
                                         .Where(t => t.ProductTypeId == id)
                                         
                                         .ToListAsync();

            var items = new List<ProductDTO>();

           
            foreach (var product in products)
            {
                var productDTO = new ProductDTO()
                {
                    ProductId = product.Id,
                    Number = product.Number,
                    Manufacturer =product.Manufacturer,
                    Amount = product.Amount,
                    PrimeCostEUR = product.PrimeCostEUR,
                    ProductTypeId = product.ProductTypeId,
                    NameType = product.ProductType.NameType
                };

                foreach (var typeParam in typeParams)
                {
                    var paramDTO = new ParameterDTO();                        
                    var value = product.ProductParameters.FirstOrDefault(t => t.ParameterId == typeParam.Id);
                    if (value != null)
                    {
                        paramDTO.Id = value.Id;
                        paramDTO.Value = value.Value;
                    }
                    paramDTO.ParameterId = typeParam.Id;
                    paramDTO.Name = typeParam.Name;
                    

                    productDTO.Parameters.Add(paramDTO);
                }

                 productDTO.Parameters.Where(y => y.ParameterId == 4)
                 .OrderBy(t => t.Value)
                 .ToList();

                 items.Add(productDTO);
            }
         

            return items;

           
        }


    public async Task<ProductDTO> AddProducts(ProductDTO productDTO)
        {
            var EntryProduct = _context.Products.Find(productDTO.ProductId);
            if (EntryProduct != null) return productDTO;

            var product = new Product
            {
                ProductTypeId = productDTO.ProductTypeId,
                Number = productDTO.Number,
                Amount = productDTO.Amount,
                PrimeCostEUR = productDTO.PrimeCostEUR,
                Manufacturer = productDTO.Manufacturer
            };

            _context.Products.Add(product);

            foreach (var paramDTO in productDTO.Parameters)
            {
                if (string.IsNullOrEmpty(paramDTO.Value))
                    continue;

                var param = new ProductParameter()
                {   ProductId = product.Id,
                    ParameterId = paramDTO.ParameterId,
                    Value = paramDTO.Value
                };
                _context.ProductParameters.Add(param);
            }

            await _context.SaveChangesAsync();

            return productDTO;

    }

    public async Task<ProductDTO> UpdateProducts(ProductDTO productDTO, int id)
        {
            var product = _context.Products.Include(t => t.ProductParameters)
                                           .Where(t => t.Id == id)
                                           .FirstOrDefault();

            product.PrimeCostEUR = productDTO.PrimeCostEUR;
            product.ProductTypeId = productDTO.ProductTypeId;
            product.Number = productDTO.Number;
            product.Amount = productDTO.Amount;
            product.PrimeCostEUR = productDTO.PrimeCostEUR;
            product.Manufacturer = productDTO.Manufacturer;

            foreach (var paramDTO in productDTO.Parameters)
            {
                if (string.IsNullOrEmpty(paramDTO.Value))
                    continue;

                if (paramDTO.Id == 0)
                {
                    var param = new ProductParameter()
                    {
                        ProductId = product.Id,
                        ParameterId = paramDTO.ParameterId,
                        Value = paramDTO.Value
                    };
                    _context.ProductParameters.Add(param);
                }
                else
                {
                    var existingParam = product.ProductParameters.Where(p => p.Id == paramDTO.Id).FirstOrDefault();
                    if (existingParam != null)
                    {
                        existingParam.Value = paramDTO.Value;
                    }

                }

            }

            await _context.SaveChangesAsync();


            return productDTO;

     }

    public async Task<Product> DeleteProducts(int id)
    {
            var product = _context.Products
                   .Include(p => p.ProductType)
                   .Include(pp => pp.ProductParameters)
                   .Where(i => i.Id == id).FirstOrDefault();
         //var pp = _context.Products.Include(t => t.ProductParameters).FirstOrDefault();
            
         //_context.Products.Remove(pp);
         _context.Products.Remove(product);
         await _context.SaveChangesAsync();

         return product;
    }

        public async Task<IEnumerable<ProductDTO>> SortProducs(int id)
        {
            var products = await _context.Products
              .Include(p => p.ProductParameters)
              .Where(prod => prod.ProductTypeId == id)
              .OrderBy(v => v.ProductParameters.Where(g => g.ParameterId == 4)
                   .OrderBy(t => Convert.ToInt32(t.Value)).FirstOrDefault().Value)
              .Select(prod => new ProductDTO
              {
                  ProductId = prod.Id,
                  Number = prod.Number,
                  Amount = prod.Amount,
                  PrimeCostEUR = prod.PrimeCostEUR,
                  ProductTypeId = prod.ProductTypeId,
                  Manufacturer = prod.Manufacturer,
                  Parameters = prod.ProductParameters
                    .Select(par => new ParameterDTO
                    {
                        Id = par.Id,
                        ParameterId = par.ParameterId,
                        Value = par.Value,
                        Name = par.Parameter.Name
                    })
                    .ToList()
              })
              .ToListAsync();


            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductParam(int id)
        {
            var products = await _context.Products
              .Include(p => p.ProductParameters)
              .Where(prod => prod.Id == id)
              .Select(prod => new ProductDTO
              {
                  ProductId = prod.Id,
                  Number = prod.Number,
                  Amount = prod.Amount,
                  PrimeCostEUR = prod.PrimeCostEUR,
                  ProductTypeId = prod.ProductTypeId,
                  Manufacturer = prod.Manufacturer,
                  Parameters = prod.ProductParameters
                    .Select(par => new ParameterDTO
                    {
                        Id = par.Id,
                        ParameterId = par.ParameterId,
                        Value = par.Value,
                        Name = par.Parameter.Name
                    })

                    .ToList()
              })

              .ToListAsync();


            return products;
        }

        //public double GetSumAll(int id)
        //{
        //    return _context.Products
        //        .Include(p => p.ProductParameters)
        //       // .Where(a => a.ProductParameters.Where(f => f.Value == "63"))
        //        .Sum(a => a.Amount);
        //}


        //var EntryProduct = _context.Products.Find(ProductDTO.ProductId);

        //if (EntryProduct == null)
        //{

        //    _context.Products.Add(new Product
        //    {
        //        Id = ProductDTO.ProductId,
        //        Number = ProductDTO.Number,
        //        Amount = ProductDTO.Amount,
        //        PrimeCostEUR = ProductDTO.PrimeCostEUR,
        //    });
        //    _context.SaveChanges();

        //    foreach (var i in ProductDTO.Parameters)
        //    {
        //        var EntryParameter = await _context.Parameters.FindAsync(i.Id);
        //        if (EntryParameter != null)
        //        {
        //            _context.ProductParameters.Add(
        //              new ProductParameter
        //              {
        //                  ProductId = ProductDTO.ProductId,
        //                  ParameterId = i.Id,
        //                  Value = i.Value
        //              });
        //            _context.SaveChanges();
        //        }
        //    }

        //}

        //return ProductDTO;
        //var items = await _context.Products
        //                 .SelectMany(p => p.ProductParameters)
        //                 .Select(pp => new ProductDTO
        //                 {
        //                     ProductId = pp.ProductId,
        //                     Number = pp.Product.Number,
        //                     Amount = pp.Product.Amount,
        //                     PrimeCostEUR = pp.Product.PrimeCostEUR,
        //                     NameType = pp.Product.ProductType.NameType,
        //                     ProductTypeId = pp.Product.ProductTypeId,
        //                     Name = pp.Parameter.Name,
        //                     Value = pp.Value
        //                 })
        //                .Where(pp => pp.ProductTypeId == id)
        //                .ToListAsync();
        //return items;
    }
}
