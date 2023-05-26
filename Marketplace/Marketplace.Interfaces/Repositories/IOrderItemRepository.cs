using Marketplace.Entities.Entities;

namespace Marketplace.Interfaces.Repositories
{
    public interface IOrderItemRepository
    {
        Task<int> SaveOrderItem(OrderItem orderItem);
        Task<int> UpdateOrderItem(OrderItem orderItem);
        Task DeleteOrderItem(int idOrderItem);
        Task<List<OrderItem>> GetAllOrderItems();
        Task<OrderItem> GetOrderItemByIdAsync(int idOrderItem);
    }
}
