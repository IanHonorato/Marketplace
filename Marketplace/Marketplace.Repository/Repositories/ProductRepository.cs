using Marketplace.Data.Data;
using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketplaceContext _context;

        public ProductRepository(MarketplaceContext context)
        {
            _context = context;
        }
        public async Task DeleteProduct(int idProduct)
        {
            var product = await _context.Product.FindAsync(idProduct);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int idProduct)
        {
            var product = await _context.Product.FindAsync(idProduct);
            return product;
        }

        public async Task<int> SaveProduct(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();

            return product.IdProduct;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return product.IdProduct;
        }
    }
}
