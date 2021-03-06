﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GdmStore.Models;
using GdmStore.DTO;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.AspNetCore.Authorization;
using GdmStore.Services.Interfaces;

namespace GdmStore.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly DataContext _context;
    
        public ProductService(DataContext context) : base(context)
        {
            _context = context;
            
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            Product p = await GetItem(product.Id);
            p.Name = product.Name;
            p.Number = product.Number;
            p.Amount = product.Amount;
            p.PrimeCostEUR = product.PrimeCostEUR;
            p.ProductTypeId = product.ProductTypeId;
            p.ProductParameters = product.ProductParameters;
            await _context.SaveChangesAsync();
            return  product;
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
                  NameType = prod.ProductType.NameType,
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

        public async Task<IQueryable<ProductDTO>> SortProducsByParameters(int TypeId, bool StateOrder = true)
        {
            string param = "Стандарт";
            int paramId = 2; // тип штока 
            int paramDiameterId = 4;
            string diameter = "60";

            var products = await _context.ProductParameters
                           .Include(p => p.Product)
                           .Where(p => p.Product.ProductTypeId == TypeId && p.Value == param && p.ParameterId == paramId)
                           .Select(p => p.Product)
                           .Include(p => p.ProductType)
                           .Include(p => p.ProductParameters)
                           .ToListAsync();

            if (StateOrder == true)
            {
                products = products.OrderBy(v => v.ProductParameters.Where(g => g.ParameterId == paramDiameterId)
                   .OrderBy(t => Convert.ToInt32(t.Product.Amount)).FirstOrDefault().Product.Amount).ToList();
                
            }
            else
            {
                products = products.OrderByDescending(v => v.ProductParameters.Where(g => g.ParameterId == paramDiameterId)
                .OrderByDescending(t => t.Product.Amount).FirstOrDefault().Product.Amount).ToList();
            }

            var items = new List<ProductDTO>();

            foreach (var product in products)
            {
                var foundParam = product.ProductParameters.Where(pp => pp.ParameterId == paramDiameterId && pp.Value == diameter)
                    .FirstOrDefault();
                if (foundParam == null)
                    continue;

                var productDTO = new ProductDTO()
                {
                    ProductId = product.Id,
                    Number = product.Number,
                    Manufacturer = product.Manufacturer,
                    Amount = product.Amount,
                    PrimeCostEUR = product.PrimeCostEUR,
                    ProductTypeId = product.ProductTypeId,
                    NameType = product.ProductType.NameType
                };

                foreach (var typeParam in product.ProductParameters)
                {
                    var paramDTO = new ParameterDTO();
                    var value = product.ProductParameters.FirstOrDefault(t => t.ParameterId == typeParam.Id);
                    if (value != null)
                    {
                        paramDTO.Id = value.Id;
                        paramDTO.Value = value.Value;
                    }
                    paramDTO.Id = typeParam.Id;
                    paramDTO.Name = typeParam.Product.ProductType.NameType;
                    paramDTO.ParameterId = typeParam.ParameterId;
                    paramDTO.Value = typeParam.Value;

                    productDTO.Parameters.Add(paramDTO);
                }

                items.Add(productDTO);
            }

            return items.AsQueryable();
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

        public async Task<IEnumerable<ProductOrderDTO>> GetParamForOrder(int id)
        {
            var param = await _context.Products
                                      .Where(p => p.Id == id)
                                      .Select(m => new ProductOrderDTO
                                      {
                                          Number = m.Number,
                                          PrimeCostEUR = m.PrimeCostEUR
                                      }).ToListAsync();

            return param;

        }


    }
}
