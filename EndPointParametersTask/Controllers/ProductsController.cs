using EndPointParametersTask.Models.DTOs;
using EndPointParametersTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace EndPointParametersTask.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        // Constructor for ProductsController.

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var products = await _service.GetAllProductsAsync(pageNumber, pageSize);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] InputProductDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _service.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] InputProductDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedProduct = await _service.UpdateProductAsync(id, productDto);
            if (updatedProduct == null) return NotFound();

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var success = await _service.DeleteProductAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
        
}

