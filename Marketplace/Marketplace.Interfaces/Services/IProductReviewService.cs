using Marketplace.Models.Dto;

namespace Marketplace.Interfaces.Services
{
    public interface IProductReviewService
    {
        Task<int> SaveProductReview(ProductReviewCreateDto productReviewDto);
        Task<int> UpdateProductReview(ProductReviewUpdateDto productReviewDto);
        Task DeleteProductReview(int idProductReview);
        Task<List<ProductReviewResponseDto>> GetAllReviews();
        Task<ProductReviewResponseDto> GetProductReviewByIdAsync(int idProductReview);
    }
}
