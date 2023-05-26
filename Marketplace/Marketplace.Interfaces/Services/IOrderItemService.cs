using Marketplace.Models.Dto;

namespace Marketplace.Interfaces.Services
{
    public interface IOrderItemService
    {
        Task<int> SaveOrderItem(OrderItemCreateDto orderItemDto);
        Task<int> UpdateOrderItem(OrderItemUpdateDto orderItemDto);
        Task DeleteOrderItem(int idOrderItem);
        Task<List<OrderItemResponseDto>> GetAllOrderItems();
        Task<OrderItemResponseDto> GetOrderItemByIdAsync(int idOrderItem);
    }
}
