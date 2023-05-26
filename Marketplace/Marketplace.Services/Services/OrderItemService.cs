using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;

namespace Marketplace.Services.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository) 
        {
            _orderItemRepository = orderItemRepository;
        }

        public Task DeleteOrderItem(int idOrderItem)
        {
            var request = _orderItemRepository.DeleteOrderItem(idOrderItem);
            return request;
        }

        public async Task<List<OrderItemResponseDto>> GetAllOrderItems()
        {
            var orderItems = await _orderItemRepository.GetAllOrderItems();
            var orderItemResponseDtos = new List<OrderItemResponseDto>();

            foreach (var orderItem in orderItems)
            {
                orderItemResponseDtos.Add(new OrderItemResponseDto
                {
                    IdOrderItem = orderItem.IdOrderItems,
                    Quantity = orderItem.Quantity,
                    Price = orderItem.Price,
                    OrderId = orderItem.OrderId,
                    ProductId = orderItem.ProductId
                });
            }

            return orderItemResponseDtos;
        }

        public async Task<OrderItemResponseDto> GetOrderItemByIdAsync(int idOrderItem)
        {
            var orderItem = await _orderItemRepository.GetOrderItemByIdAsync(idOrderItem);

            if(orderItem != null)
            {
                var orderItemResponseDto = new OrderItemResponseDto
                {
                    IdOrderItem = orderItem.IdOrderItems,
                    Quantity = orderItem.Quantity,
                    Price = orderItem.Price,
                    OrderId = orderItem.OrderId,
                    ProductId = orderItem.ProductId
                };

                return orderItemResponseDto;
            }

            return null;
        }

        public async Task<int> SaveOrderItem(OrderItemCreateDto orderItemDto)
        {
            var orderItem = new OrderItem(orderItemDto.OrderId, orderItemDto.ProductId, orderItemDto.Quantity, orderItemDto.Price);
            var id = await _orderItemRepository.SaveOrderItem(orderItem);

            return id;
        }

        public async Task<int> UpdateOrderItem(OrderItemUpdateDto orderItemDto)
        {
            var orderItem = await _orderItemRepository.GetOrderItemByIdAsync(orderItemDto.IdOrderItem);

            if(orderItem != null)
            {
                if (orderItemDto.Quantity > 0) orderItem.Quantity = orderItemDto.Quantity;
                if (orderItemDto.Price > 0) orderItem.Price = orderItemDto.Price;
                if (orderItemDto.OrderId != 0) orderItem.OrderId = orderItemDto.OrderId;
                if (orderItemDto.ProductId != 0) orderItem.ProductId = orderItemDto.ProductId;

                int id = await _orderItemRepository.UpdateOrderItem(orderItem);

                return id;
            }

            return 0;
        }
    }
}