using Marketplace.Data.Data;
using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Repository.Repositories
{
    public class PaymentInfoRepository : IPaymentInfoRepository
    {
        private readonly MarketplaceContext _context;
        public PaymentInfoRepository(MarketplaceContext context) 
        {
            _context = context;
        }
        public async Task DeletePaymentInfo(int idPaymentInfo)
        {
            var paymentInfo = await _context.PaymentInfo.FindAsync(idPaymentInfo);
            if(paymentInfo != null)
            {
                _context.PaymentInfo.Remove(paymentInfo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PaymentInfo>> GetAllPaymentInfo()
        {
            return await _context.PaymentInfo.ToListAsync();
        }

        public async Task<PaymentInfo> GetPaymentInfoByIdAsync(int idPaymentInfo)
        {
            var paymentInfo = await _context.PaymentInfo.FindAsync(idPaymentInfo);
            return paymentInfo;
        }

        public async Task<int> SavePaymentInfo(PaymentInfo paymentInfo)
        {
            await _context.PaymentInfo.AddAsync(paymentInfo);
            await _context.SaveChangesAsync();

            return paymentInfo.IdPaymentInfo;
        }

        public async Task<int> UpdatePaymentInfo(PaymentInfo paymentInfo)
        {
            _context.PaymentInfo.Update(paymentInfo);
            await _context.SaveChangesAsync();

            return paymentInfo.IdPaymentInfo;
        }
    }
}
