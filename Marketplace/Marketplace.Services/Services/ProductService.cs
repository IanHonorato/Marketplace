using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;

namespace Marketplace.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task DeleteProduct(int idSeller)
        {
            var request = _productRepository.DeleteProduct(idSeller);
            return request;
        }

        public async Task<List<ProductResponseDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            var productResponseDtos = new List<ProductResponseDto>();

            foreach(var product in products) 
            {
                productResponseDtos.Add(new ProductResponseDto
                {
                    IDProduct = product.IdProduct,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Stock = product.Stock,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt,
                    SellerId = product.SellerId
                });
            }

            return productResponseDtos;
        }

        public async Task<ProductResponseDto> GetProductByIdAsync(int idProduct)
        {
            var product = await _productRepository.GetProductByIdAsync(idProduct);

            if(product != null)
            {
                var productResponseDto = new ProductResponseDto
                {
                    IDProduct = product.IdProduct,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Stock = product.Stock,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt,
                    SellerId = product.SellerId
                };

                return productResponseDto;
            }
            return null;
        }

        public async Task<int> SaveProduct(ProductCreateDto productDto)
        {
            var product = new Product(productDto.SellerId, productDto.Name, productDto.Description, productDto.ImageUrl, productDto.Price, productDto.Stock,
                DateTime.Now, DateTime.Now);
            var id = await _productRepository.SaveProduct(product);

            return id;
        }

        public async Task<int> UpdateProduct(ProductUpdateDto productDto)
        {
            var product = await _productRepository.GetProductByIdAsync(productDto.IDProduct);

            if(product != null)
            {
                if (productDto.Name != null) product.Name = productDto.Name;
                if (productDto.Description != null) product.Description = productDto.Description;
                if (productDto.ImageUrl != null) product.ImageUrl = productDto.ImageUrl;
                if (productDto.Price != 0) product.Price = productDto.Price;
                product.Stock = productDto.Stock;
                product.UpdatedAt = DateTime.Now;
                if(productDto.SellerId != 0) product.SellerId = productDto.SellerId;

                int id = await _productRepository.UpdateProduct(product);

                return id;
            }

            return 0;
        }
    }
}
