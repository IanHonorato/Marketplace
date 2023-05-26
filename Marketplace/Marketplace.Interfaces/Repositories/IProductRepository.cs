using Marketplace.Entities.Entities;

namespace Marketplace.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<int> SaveProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task DeleteProduct(int idProduct);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductByIdAsync(int idProduct);
    }
}
