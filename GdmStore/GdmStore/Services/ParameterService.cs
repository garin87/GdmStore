using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GdmStore.Models;
using GdmStore.Services;

namespace GdmStore.Services
{
    public class ParameterService //: BaseService<Parameter>
    {
        private readonly DataContext _context;

        public ParameterService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parameter>> GetAll()
        {
            return _context.Parameters.ToList();
        }

        public async Task<Parameter> GetParameter(long id)
        {
            return await _context.Parameters.FindAsync(id);
        }

        public async Task<Parameter> AddParameter(Parameter parameter)
        {
            _context.Parameters.Add(parameter);
            await _context.SaveChangesAsync();

            return parameter;
        }

        public async Task<Parameter> DeleteParameter(long id)
        {
            var parameter = await _context.Parameters.FindAsync(id);
            _context.Parameters.Remove(parameter);
            await _context.SaveChangesAsync();

            return parameter;
        }

        public async Task<Parameter> UpdateParameter(long id, Parameter parameter)
        {
            Parameter p = await GetParameter(parameter.ParameterId);
            p.Name = parameter.Name;
           // p.Description = parameter.Description;
          //  p.SteelGrade = parameter.SteelGrade;
          //  p.TypeTube = parameter.TypeTube;
          //  p.ProductTypeId = parameter.ProductTypeId;
          //  p.Diameter = parameter.Diameter;
            await _context.SaveChangesAsync();
            return parameter;
        }
    }
}
