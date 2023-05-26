using Marketplace.Data.Data;
using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MarketplaceContext _context;

        public OrderRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public async Task DeleteOrder(int idOrder)
        {
            var order = await _context.Order.FindAsync(idOrder);
            if (order != null)
            {
                _context.Order.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int idOrder)
        {
            var order = await _context.Order.FindAsync(idOrder);
            return order;
        }

        public async Task<int> SaveOrder(Order order)
        {
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            return order.IdOrder;
        }

        public async Task<int> UpdateOrder(Order order)
        {
            _context.Order.Update(order);
            await _context.SaveChangesAsync();

            return order.IdOrder;
        }
    }
}
