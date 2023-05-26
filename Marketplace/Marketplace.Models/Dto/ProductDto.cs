namespace Marketplace.Models.Dto
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int SellerId { get; set; }
    }

    public class ProductCreateDto : ProductDto
    {
    }

    public class ProductUpdateDto : ProductDto
    {
        public int IDProduct { get; set; }
    }

    public class ProductResponseDto : ProductDto
    {
        public int IDProduct { get; set; }
    }
}
