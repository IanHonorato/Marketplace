using Marketplace.Entities.Entities;

namespace Marketplace.Models.Dto
{
    public class ProductReviewDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
    public class ProductReviewCreateDto : ProductReviewDto { }
    public class ProductReviewUpdateDto : ProductReviewDto 
    { 
        public int IdProductReview { get; set; }
    }

    public class ProductReviewResponseDto : ProductReviewDto
    {
        public int IdProductReview { get; set; }
    }
}
