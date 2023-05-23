using Marketplace.Entities.Entities;

namespace Marketplace.Interfaces.Repositories
{
    public interface ISellerRepository
    {
        Task<int> SaveSeller(Seller seller);
        Task<int> UpdateSeller(Seller seller);
        Task DeleteSeller(int idSeller);
        Task<List<Seller>> GetAllSellers();
        Task<Seller> GetSellerByIdAsync(int idSeller);
    }
}
