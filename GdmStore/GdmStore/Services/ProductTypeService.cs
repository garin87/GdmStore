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
    public class ProductTypeService
    {
        private readonly DataContext _context;

        public ProductTypeService()
        {
            _context = new DataContext();
        }
    }
}
