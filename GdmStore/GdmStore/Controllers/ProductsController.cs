using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GdmStore.Models;
using GdmStore.DTO;
using GdmStore.Services;

namespace GdmStore
{
    [Authorize(Roles = "admin")] 
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly DataContext _context;
        private ProductService _productService;
 
        public ProductsController(DataContext context) 
        {
            _context = context;
            _productService = new ProductService(_context);
        }

        // GET: api/Products/GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Ok(_productService.GetAll());
        }

        // GET: api/Products/GetProduct/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {   
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productService.GetItem(id);

            if (product == null)
            {
                return NotFound();
            }
            
            return Ok(product);
        }

        // POST: api/Products/PostProduct
        [HttpPost]
        public async Task<IActionResult> PostProduct(Product product)
        {   
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productNew = await _productService.AddItem(product);

            return Ok(productNew);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productService.DeleteItem(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/PutProduct/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

           await _productService.UpdateProduct(id, product);

           return NoContent();
        }

        //GET: api/Products/GetProducts/1
        [HttpGet]
        [Route("GetProducts/{id}")]
        public async Task<IEnumerable<ProductDTO>> GetProducts([FromRoute] int id)
        {
            return await _productService.GetProducts(id);
        }

        [HttpPost]
        [Route("AddProducts")]
        public async Task<ProductDTO> AddProducts([FromBody] ProductDTO ProductDTO)
        {
            return await _productService.AddProducts(ProductDTO);
        }


        [HttpPut]
        [Route("UpdateProducts/{id}")]
        public async Task<ProductDTO> UpdateProducts(ProductDTO ProductDTO, int id)
        {
            return await _productService.UpdateProducts(ProductDTO, id);
        }

        [HttpDelete]
        [Route("DeleteProducts/{id}")]
        public async Task<Product> DeleteProducts(int id)
        {
            return await _productService.DeleteProducts(id);
        }
      //  [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("SortProducts/{id}")]
        public async Task<IEnumerable<ProductDTO>> SortProducts([FromRoute] int id)
        {
            return await _productService.SortProducs(id);
        }

        [HttpGet]
        [Route("SortProducsByParameters/{id}")]
        public async Task<IEnumerable<ProductDTO>> SortProducsByParameters([FromRoute] int id, [FromQuery] bool StateOrder)
        {
            return await _productService.SortProducsByParameters(id, StateOrder);
        }

        [HttpGet]
        [Route("GetProductParam/{id}")]
        public async Task<IEnumerable<ProductDTO>> GetProductParam([FromRoute] int id)
        {
            return await _productService.GetProductParam(id);
        }

        [HttpGet]
        [Route("GetParamForOrder/{id}")]
        public async Task<IEnumerable<ProductOrderDTO>> GetParamForOrder([FromRoute] int id)
        {
            return await _productService.GetParamForOrder(id);
        }

    }
}