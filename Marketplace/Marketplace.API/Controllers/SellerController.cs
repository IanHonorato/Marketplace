using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    public class SellerController : Controller
    {
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("seller/{id}")]
        public async Task<ActionResult<SellerResponseDto>> GetSellerById(int id)
        {
            var seller = await _sellerService.GetSellerByIdAsync(id);
            if (seller == null)
            {
                return NotFound();
            }

            return Ok(seller);
        }

        [HttpGet("seller")]
        public async Task<ActionResult<List<SellerResponseDto>>> GetAllSeller()
        {
            var sellers = await _sellerService.GetAllSellers();
            return Ok(sellers);
        }

        [HttpPost("seller")]
        public async Task<ActionResult<int>> CreateSeller(SellerCreateDto seller)
        {
            var sellerId = await _sellerService.SaveSeller(seller);
            return CreatedAtAction(nameof(GetSellerById), new { id = sellerId }, sellerId);
        }

        [HttpPut("seller")]
        public async Task<ActionResult> UpdateSeller(SellerUpdateDto seller)
        {
            await _sellerService.UpdateSeller(seller);
            return NoContent();
        }

        [HttpDelete("seller/{id}")]
        public async Task<ActionResult> DeleteSeller(int id)
        {
            await _sellerService.DeleteSeller(id);
            return NoContent();
        }
    }
}
