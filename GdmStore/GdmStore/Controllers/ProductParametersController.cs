using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GdmStore.Models;

namespace GdmStore
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductParametersController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductParametersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProductParameters
        [HttpGet]
        public IEnumerable<ProductParameter> GetProductParameters()
        {
            return _context.ProductParameters;
        }

        // GET: api/ProductParameters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductParameter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productParameter = await _context.ProductParameters.FindAsync(id);

            if (productParameter == null)
            {
                return NotFound();
            }

            return Ok(productParameter);
        }

        // PUT: api/ProductParameters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductParameter([FromRoute] int id, [FromBody] ProductParameter productParameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productParameter.ProductParameterId)
            {
                return BadRequest();
            }

            _context.Entry(productParameter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductParameterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductParameters
        [HttpPost]
        public async Task<IActionResult> PostProductParameter([FromBody] ProductParameter productParameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductParameters.Add(productParameter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductParameter", new { id = productParameter.ProductParameterId }, productParameter);
        }

        // DELETE: api/ProductParameters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductParameter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productParameter = await _context.ProductParameters.FindAsync(id);
            if (productParameter == null)
            {
                return NotFound();
            }

            _context.ProductParameters.Remove(productParameter);
            await _context.SaveChangesAsync();

            return Ok(productParameter);
        }

        private bool ProductParameterExists(int id)
        {
            return _context.ProductParameters.Any(e => e.ProductParameterId == id);
        }
    }
}