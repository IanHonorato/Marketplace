using Marketplace.Entities.Entities;

namespace Marketplace.Interfaces.Repositories
{
    public interface IPaymentInfoRepository
    {
        Task<int> SavePaymentInfo(PaymentInfo paymentInfo);
        Task<int> UpdatePaymentInfo(PaymentInfo paymentInfo);
        Task DeletePaymentInfo(int idPaymentInfo);
        Task<List<PaymentInfo>> GetAllPaymentInfo();
        Task<PaymentInfo> GetPaymentInfoByIdAsync(int idPaymentInfo);
    }
}
