using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;

namespace Marketplace.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task DeleteOrder(int idOrder)
        {
            var request = _orderRepository.DeleteOrder(idOrder);
            return request;
        }

        public async Task<List<OrderResponseDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            var orderResponseDtos = new List<OrderResponseDto>();

            foreach(var order in orders)
            {
                orderResponseDtos.Add(new OrderResponseDto
                {
                    IdOrder = order.IdOrder,
                    TotalPrice = order.TotalPrice,
                    Status = order.Status,
                    Address = order.Address,
                    City = order.City,
                    State = order.State,
                    Country = order.Country,
                    ZipCode = order.ZipCode,
                    CreatedAt = order.CreatedAt,
                    UpdatedAt = order.UpdatedAt,
                    UserId = order.UserId
                });
            }

            return orderResponseDtos;
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(int idOrder)
        {
            var order = await _orderRepository.GetOrderByIdAsync(idOrder);

            if(order != null)
            {
                var orderResponseDto = new OrderResponseDto
                {
                    IdOrder = order.IdOrder,
                    TotalPrice = order.TotalPrice,
                    Status = order.Status,
                    Address = order.Address,
                    City = order.City,
                    State = order.State,
                    Country = order.Country,
                    ZipCode = order.ZipCode,
                    CreatedAt = order.CreatedAt,
                    UpdatedAt = order.UpdatedAt,
                    UserId = order.UserId
                };

                return orderResponseDto;
            }
            return null;
        }

        public async Task<int> SaveOrder(OrderCreateDto orderDto)
        {
            var order = new Order(orderDto.UserId, orderDto.TotalPrice, DateTime.Now, DateTime.Now, orderDto.Status, orderDto.Address, orderDto.City, 
                orderDto.State, orderDto.Country, orderDto.ZipCode);

            var id = await _orderRepository.SaveOrder(order);

            return id;
        }

        public async Task<int> UpdateOrder(OrderUpdateDto orderDto)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderDto.IdOrder);

            if(order != null)
            {
                if (orderDto.TotalPrice != 0) order.TotalPrice = orderDto.TotalPrice;    
                if (orderDto.Address != null) order.Address = orderDto.Address;
                if (orderDto.City != null) order.City = orderDto.City;
                if (orderDto.State != null) order.State = orderDto.State;
                if (orderDto.Country != null) order.Country = orderDto.Country;
                if (orderDto.ZipCode != null) order.ZipCode = orderDto.ZipCode;
                if (order.UserId != 0) order.UserId = orderDto.UserId;
                order.UpdatedAt = DateTime.Now;
                order.Status = orderDto.Status;

                int id = await _orderRepository.UpdateOrder(order);

                return id;
            }

            return 0;
        }
    }
}