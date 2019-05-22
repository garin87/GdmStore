using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GdmStore.Models;
using GdmStore.Services;
using GdmStore.Services.Interfaces;

namespace GdmStore.Services
{
    public class ProductTypeService : BaseService<ProductType>, IProductTypeService
    {
        private readonly DataContext _context;

        public ProductTypeService(DataContext context) :base(context)
        {
            _context = new DataContext();
        }

    }
}
