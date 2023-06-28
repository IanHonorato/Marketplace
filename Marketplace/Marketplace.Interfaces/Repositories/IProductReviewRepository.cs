using Marketplace.Entities.Entities;

namespace Marketplace.Interfaces.Repositories
{
    public interface IProductReviewRepository
    {
        Task<int> SaveProductReview(ProductReview productReview);
        Task<int> UpdateProductReview(ProductReview productReview);
        Task DeleteProductReview(int idProductReview);
        Task<List<ProductReview>> GetAllProductReview();
        Task<ProductReview> GetProductReviewByIdAsync(int idProductReview);
    }
}
