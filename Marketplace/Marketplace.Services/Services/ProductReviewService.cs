using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;

namespace Marketplace.Services.Services
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IProductReviewRepository _productReviewRepository;
        public ProductReviewService(IProductReviewRepository productReviewRepository)
        {
            _productReviewRepository = productReviewRepository;
        }

        public Task DeleteProductReview(int idProductReview)
        {
            var request = _productReviewRepository.DeleteProductReview(idProductReview);
            return request;
        }

        public async Task<List<ProductReviewResponseDto>> GetAllReviews()
        {
            var reviews = await _productReviewRepository.GetAllProductReview();
            var reviewResponseDtos = new List<ProductReviewResponseDto>();

            foreach (var review in reviews)
            {
                reviewResponseDtos.Add(new ProductReviewResponseDto
                {
                    IdProductReview = review.IdProductReview,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    CreatedAt = review.CreatedAt,
                    UpdatedAt = review.UpdatedAt,
                    UserId = review.UserId,
                    ProductId = review.ProductId
                });
            }

            return reviewResponseDtos;
        }

        public async Task<ProductReviewResponseDto> GetProductReviewByIdAsync(int idProductReview)
        {
            var review = await _productReviewRepository.GetProductReviewByIdAsync(idProductReview);

            if(review != null)
            {
                var productReviewResponseDto = new ProductReviewResponseDto
                {
                    IdProductReview = review.IdProductReview,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    CreatedAt = review.CreatedAt,
                    UpdatedAt = review.UpdatedAt,
                    UserId = review.UserId,
                    ProductId = review.ProductId
                };

                return productReviewResponseDto;
            }

            return null;
        }

        public async Task<int> SaveProductReview(ProductReviewCreateDto productReviewDto)
        {
            var review = new ProductReview(productReviewDto.UserId, productReviewDto.ProductId, productReviewDto.Rating, productReviewDto.Comment, 
                DateTime.Now, DateTime.Now);

            var id = await _productReviewRepository.SaveProductReview(review);

            return id;
        }

        public async Task<int> UpdateProductReview(ProductReviewUpdateDto productReviewDto)
        {
            var review = await _productReviewRepository.GetProductReviewByIdAsync(productReviewDto.IdProductReview);

            if(review != null)
            {
                if (productReviewDto.Rating != 0) review.Rating = productReviewDto.Rating;
                if (productReviewDto.Comment != null) review.Comment = productReviewDto.Comment;
                if (productReviewDto.UserId != 0) review.UserId = productReviewDto.UserId;
                if (productReviewDto.ProductId != 0) review.ProductId = productReviewDto.ProductId;
                review.UpdatedAt = DateTime.Now;
                
                int id = await _productReviewRepository.UpdateProductReview(review);

                return id;
            }

            return 0;
        }
    }
}
