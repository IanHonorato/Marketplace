namespace Marketplace.Models.Dto
{
    public class OrderItemDto
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }

    public class OrderItemCreateDto : OrderItemDto
    {
    }

    public class OrderItemUpdateDto : OrderItemDto
    {
        public int IdOrderItem { get; set; }
    }

    public class OrderItemResponseDto : OrderItemDto
    {
        public int IdOrderItem { get; set; }
    }
}
