using Marketplace.Data.Data;
using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Repository.Repositories
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly MarketplaceContext _context;
        public ProductReviewRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public async Task DeleteProductReview(int idProductReview)
        {
            var productReview = await _context.ProductReview.FindAsync(idProductReview);
            if(productReview != null)
            {
                _context.ProductReview.Remove(productReview);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductReview>> GetAllProductReview()
        {
            return await _context.ProductReview.ToListAsync();
        }

        public async Task<ProductReview> GetProductReviewByIdAsync(int idProductReview)
        {
            var productReview = await _context.ProductReview.FindAsync(idProductReview);
            return productReview;
        }

        public async Task<int> SaveProductReview(ProductReview productReview)
        {
            await _context.ProductReview.AddAsync(productReview);
            await _context.SaveChangesAsync();

            return productReview.IdProductReview;
        }

        public async Task<int> UpdateProductReview(ProductReview productReview)
        {
            _context.ProductReview.Update(productReview);
            await _context.SaveChangesAsync();

            return productReview.IdProductReview;
        }
    }
}
