using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GdmStore.Models;
using GdmStore.Services;

namespace GdmStore
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        private readonly DataContext _context;
        private ParameterService _parameterService;

        public ParametersController(DataContext context)
        {
            _context = context;
            _parameterService = new ParameterService(_context);

        }
     
        // GET: api/Parameters
        [HttpGet]
        public IActionResult GetParameters()
        {
            return Ok( _parameterService.GetAll()); 
        }

        // GET: api/Parameters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParameter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parameter = await _parameterService.GetItem(id);

            if (parameter == null)
            {
                return NotFound();
            }

            return Ok(parameter);
        }

        // PUT: api/Parameters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParameter([FromRoute] int id, [FromBody] Parameter parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parameter.Id)
            {
                return BadRequest();
            }

            await _parameterService.UpdateParameter(id, parameter);

            return NoContent();
        }

        // POST: api/Parameters
        [HttpPost]
        public async Task<IActionResult> PostParameter([FromBody] Parameter parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parameterNew = await _parameterService.AddItem(parameter);

            return Ok(parameterNew);
        }

        // DELETE: api/Parameters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParameter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parameter = await _parameterService.DeleteItem(id);

            if (parameter == null)
            {
                return NotFound();
            }

            _context.Parameters.Remove(parameter);
            await _context.SaveChangesAsync();

            return Ok(parameter);
        }

        //private bool ParameterExists(long id) => _context.Parameters.Any(e => e.ParameterId == id);
      
    }
}