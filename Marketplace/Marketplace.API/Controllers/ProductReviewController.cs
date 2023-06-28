using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    public class ProductReviewController : Controller
    {
        private readonly IProductReviewService _productReviewService;

        public ProductReviewController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("product-review/{id}")]
        public async Task<ActionResult<ProductReviewResponseDto>> GetProductReviewById(int id)
        {
            var productReview = await _productReviewService.GetProductReviewByIdAsync(id);
            if (productReview == null)
            {
                return NotFound();
            }

            return Ok(productReview);
        }

        [HttpGet("product-review")]
        public async Task<ActionResult<List<ProductReviewResponseDto>>> GetAllProductReviews()
        {
            var reviews = await _productReviewService.GetAllReviews();
            return Ok(reviews);
        }

        [HttpPost("product-review")]
        public async Task<ActionResult<int>> CreateProductReview(ProductReviewCreateDto productReview)
        {
            var productReviewId = await _productReviewService.SaveProductReview(productReview);
            return CreatedAtAction(nameof(GetProductReviewById), new { id = productReviewId}, productReviewId);
        }

        [HttpPut("product-review")]
        public async Task<ActionResult> UpdateProductReview(ProductReviewUpdateDto productReview)
        {
            await _productReviewService.UpdateProductReview(productReview);
            return NoContent();
        }

        [HttpDelete("product-review/{id}")]
        public async Task<ActionResult> DeleteProductReview(int id)
        {
            await _productReviewService.DeleteProductReview(id);
            return NoContent();
        }
    }
}
