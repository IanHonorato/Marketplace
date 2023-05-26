using Marketplace.Entities.Entities;

namespace Marketplace.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<int> SaveOrder(Order order);
        Task<int> UpdateOrder(Order order);
        Task DeleteOrder(int idOrder);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderByIdAsync(int idOrder);
    }
}
