using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("product")]
        public async Task<ActionResult<List<UserResponseDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPost("product")]
        public async Task<ActionResult<int>> CreateProduct(ProductCreateDto product)
        {
            var productId = await _productService.SaveProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
        }

        [HttpPut("product")]
        public async Task<ActionResult> UpdateProduct(ProductUpdateDto product)
        {
            await _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("product/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
