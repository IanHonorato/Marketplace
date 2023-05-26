using Marketplace.Models.Dto;

namespace Marketplace.Interfaces.Services
{
    public interface IProductService
    {
        Task<int> SaveProduct(ProductCreateDto productDto);
        Task<int> UpdateProduct(ProductUpdateDto productDto);
        Task DeleteProduct(int idSeller);
        Task<List<ProductResponseDto>> GetAllProducts();
        Task<ProductResponseDto> GetProductByIdAsync(int idProduct);
    }
}
