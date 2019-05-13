using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GdmStore.Models;
using GdmStore.DTO;
using GdmStore.Services;

namespace GdmStore.Services
{
    public class ProductParameterService
    {
        private readonly DataContext _context;

        public ProductParameterService(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ProductParameter>> GetProductParameters(long id)
        {
            var value = await _context.ProductParameters
                                      .Where(p => p.ParameterId == id)
                                      .GroupBy(m => new { m.ParameterId, m.Value })
                                      .Select(group => group.FirstOrDefault())
                                      .Distinct()
                                      .ToListAsync();
            return value;
        }

        public async Task<List<string>> GetProductDiameters(int id, string param, int paramId)
        {
            var value = await _context.ProductParameters.Where(pp1 => pp1.Value == param && pp1.ParameterId == paramId)
                        .Join(_context.ProductParameters.Where(pp => pp.ParameterId == id),
                                pp1 => pp1.Product.Id,
                                pp => pp.Product.Id,
                               (pp1, pp) => pp.Value)
                               .Distinct()
                               .ToListAsync();
            return value;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByDiameter(int typeId, string param, int paramId, int paramDiameterId,  string diameter)
        {           
          var products = await _context.ProductParameters
              .Include(p => p.Product)
              .Where(prod => prod.Product.ProductTypeId == typeId)
              .Where(pp1 => pp1.ParameterId == paramId && pp1.Value == param)
              .Join(_context.ProductParameters.Where(pp => pp.ParameterId == paramDiameterId && pp.Value == diameter),
                                pp1 => pp1.Product.Id,
                                pp => pp.Product.Id,
                                (pp1, pp) => new ProductDTO
                                {
                                    ProductId = pp.Id,
                                    Number = pp.Product.Number,
                                    Amount = pp.Product.Amount,
                                    PrimeCostEUR = pp.Product.PrimeCostEUR,
                                    ProductTypeId = pp.Product.ProductTypeId,
                                    Manufacturer = pp.Product.Manufacturer,
                                    Parameters = pp.Product.ProductParameters
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

        public async Task<IEnumerable<ProductParameter>> GetSortProductParameters(long id)
        {
            var value = await _context.ProductParameters.Include(y => y.Parameter)
                                       .Include(b => b.Product)
                                       .Where(p => p.ParameterId == id)
                                       .OrderBy(t => t.Value)
                                       .ToListAsync();
            return value;
        }

        public async Task<double> GetSumSteelBars(int value)
        {
            string diametr = value.ToString();

            return await _context.ProductParameters
                .Include(p => p.Product)
                .Where(n => n.Product.ProductTypeId == 1)
                .Where(f => f.Value == value.ToString())
                .SumAsync(a => a.Product.Amount);
        }

        public async Task<double> GetSumTubes(int value)
        {
            string diametr = value.ToString();

            return await _context.ProductParameters
                .Include(p => p.Product)
                .Where(n => n.Product.ProductTypeId == 2)
                .Where(f => f.Value == value.ToString())
                .SumAsync(a => a.Product.Amount);
        }

        public double GetSumAmountByParam(int typeId, string param, int paramId, int paramDiameterId, string diameter)
        {
            var sumAmount =   _context.ProductParameters
                        .Include(p => p.Product)
                        .Where(prod => prod.Product.ProductTypeId == typeId)
                        .Where(pp1 => pp1.Value == param && pp1.ParameterId == paramId)
                        .Join(_context.ProductParameters.Where(pp => pp.ParameterId == paramDiameterId && pp.Value == diameter),
                                pp1 => pp1.Product.Id,
                                pp => pp.Product.Id,
                               (pp1, pp) => new ProductParameter
                               {
                                   Product = pp1.Product
                               }).Sum(a => a.Product.Amount);

            return Math.Round(sumAmount, 2);
        }


    }
}

//var parameters = await _context.ProductParameters.Where(pp => pp.ParameterId == 2 && pp.Value == param)
//    .ToListAsync();

//var parameters2 = await _context.ProductParameters.Where(pp => pp.Id == id)
//    .ToListAsync();

//select distinct pp.Value from ProductParameters pp
//join ProductParameters pp1 on pp1.ProductId = pp.ProductId and pp1.ParameterId = 2 and pp1.Value = 'Стандарт'
//where pp.ParameterId = 4

//select distinct pp.Value from ProductParameters pp
//join ProductParameters pp1 on pp1.ProductId = pp.ProductId and pp1.ParameterId = 2 and pp1.Value = 'ТВЧ'
//where pp.ParameterId = 4