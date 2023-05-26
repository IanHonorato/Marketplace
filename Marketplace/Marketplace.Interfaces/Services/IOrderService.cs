using Marketplace.Models.Dto;

namespace Marketplace.Interfaces.Services
{
    public interface IOrderService
    {
        Task<int> SaveOrder(OrderCreateDto orderDto);
        Task<int> UpdateOrder(OrderUpdateDto orderDto);
        Task DeleteOrder(int idOrder);
        Task<List<OrderResponseDto>> GetAllOrders();
        Task<OrderResponseDto> GetOrderByIdAsync(int idOrder);
    }
}
