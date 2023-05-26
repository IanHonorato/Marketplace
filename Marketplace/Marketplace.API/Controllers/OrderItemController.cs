using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("order-item/{id}")]
        public async Task<ActionResult<OrderItemResponseDto>> GetOrderItemById(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return Ok(orderItem);
        }

        [HttpGet("order-item")]
        public async Task<ActionResult<List<OrderItemResponseDto>>> GetAllOrderItems()
        {
            var orderItems = await _orderItemService.GetAllOrderItems();
            return Ok(orderItems);
        }

        [HttpPost("order-item")]
        public async Task<ActionResult<int>> CreateOrderItem(OrderItemCreateDto orderItem)
        {
            var orderItemId = await _orderItemService.SaveOrderItem(orderItem);
            return CreatedAtAction(nameof(GetOrderItemById), new { id = orderItemId }, orderItemId);
        }

        [HttpPut("order-item")]
        public async Task<ActionResult> UpdateOrderItem(OrderItemUpdateDto orderItem)
        {
            await _orderItemService.UpdateOrderItem(orderItem);
            return NoContent();
        }

        [HttpDelete("order-item/{id}")]
        public async Task<ActionResult> DeleteOrderItem(int id)
        {
            await _orderItemService.DeleteOrderItem(id);
            return NoContent();
        }
    }
}
