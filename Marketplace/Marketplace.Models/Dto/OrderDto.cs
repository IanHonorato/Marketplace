using Marketplace.Entities.Enums;

namespace Marketplace.Models.Dto
{
    public class OrderDto
    {
        public decimal TotalPrice { get; set; }
        public Status Status { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
    }
    public class OrderCreateDto : OrderDto
    {
    }

    public class OrderUpdateDto : OrderDto
    {
        public int IdOrder { get; set; }
    }

    public class OrderResponseDto : OrderDto
    {
        public int IdOrder { get; set; }
    }
}
