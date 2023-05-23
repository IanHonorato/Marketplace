using Marketplace.Data.Data;
using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Repository.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly MarketplaceContext _context;
        public SellerRepository(MarketplaceContext context) 
        {
            _context = context;
        }
        public async Task DeleteSeller(int idSeller)
        {
            var seller = await _context.Seller.FindAsync(idSeller);
            if(seller != null)
            {
                _context.Seller.Remove(seller); 
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Seller>> GetAllSellers()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller> GetSellerByIdAsync(int idSeller)
        {
            var seller = await _context.Seller.FindAsync(idSeller);
            return seller;
        }

        public async Task<int> SaveSeller(Seller seller)
        {
            await _context.Seller.AddAsync(seller);
            await _context.SaveChangesAsync();

            return seller.IDSeller;
        }

        public async Task<int> UpdateSeller(Seller seller)
        {
            _context.Seller.Update(seller);
            await _context.SaveChangesAsync();

            return seller.IDSeller;
        }
    }
}
