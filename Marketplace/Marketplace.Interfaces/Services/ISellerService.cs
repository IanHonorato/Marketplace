using Marketplace.Models.Dto;

namespace Marketplace.Interfaces.Services
{
    public interface ISellerService
    {
        Task<int> SaveSeller(SellerCreateDto sellerDto);
        Task<int> UpdateSeller(SellerUpdateDto sellerDto);
        Task DeleteSeller(int idSeller);
        Task<List<SellerResponseDto>> GetAllSellers();
        Task<SellerResponseDto> GetSellerByIdAsync(int idSeller);
    }
}
