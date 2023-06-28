using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    public class PaymentInfoController : Controller
    {
        private readonly IPaymentInfoService _paymentInfoService;
        public PaymentInfoController(IPaymentInfoService paymentInfoService)
        {
            _paymentInfoService = paymentInfoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("payment-info/{id}")]
        public async Task<ActionResult<PaymentInfoResponseDto>> GetPaymentInfoById(int id)
        {
            var paymentInfo = await _paymentInfoService.GetPaymentInfoByIdAsync(id);
            if (paymentInfo == null)
            {
                return NotFound();
            }

            return Ok(paymentInfo);
        }

        [HttpGet("payment-info")]
        public async Task<ActionResult<List<PaymentInfoResponseDto>>> GetAllPaymentInfo()
        {
            var paymentInfo = await _paymentInfoService.GetAllPaymentInfos();
            return Ok(paymentInfo);
        }

        [HttpPost("payment-info")]
        public async Task<ActionResult<int>> CreatePaymentInfo(PaymentInfoCreateDto paymentInfo)
        {
            var paymentInfoId = await _paymentInfoService.SavePaymentInfo(paymentInfo);
            return CreatedAtAction(nameof(GetPaymentInfoById), new { id = paymentInfoId }, paymentInfoId);
        }

        [HttpPut("payment-info")]
        public async Task<ActionResult> UpdatePaymentInfo(PaymentInfoUpdateDto paymentInfo)
        {
            await _paymentInfoService.UpdatePaymentInfo(paymentInfo);
            return NoContent();
        }

        [HttpDelete("payment-info/{id}")]
        public async Task<ActionResult> DeletePaymentInfo(int id)
        {
            await _paymentInfoService.DeletePaymentInfo(id);
            return NoContent();
        }
    }
}
