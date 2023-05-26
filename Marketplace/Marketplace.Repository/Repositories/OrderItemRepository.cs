using Marketplace.Data.Data;
using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Repository.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly MarketplaceContext _context;

        public OrderItemRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public async Task DeleteOrderItem(int idOrderItem)
        {
            var orderItem = await _context.OrderItem.FindAsync(idOrderItem);
            if(orderItem != null)
            {
                _context.OrderItem.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<OrderItem>> GetAllOrderItems()
        {
            return await _context.OrderItem.ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int idOrderItem)
        {
            var orderItem = await _context.OrderItem.FindAsync(idOrderItem);
            return orderItem;
        }

        public async Task<int> SaveOrderItem(OrderItem orderItem)
        {
            await _context.OrderItem.AddAsync(orderItem);
            await _context.SaveChangesAsync();

            return orderItem.IdOrderItems;
        }

        public async Task<int> UpdateOrderItem(OrderItem orderItem)
        {
            _context.OrderItem.Update(orderItem);
            await _context.SaveChangesAsync();

            return orderItem.IdOrderItems;
        }
    }
}
