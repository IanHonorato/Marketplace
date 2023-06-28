using Marketplace.Models.Dto;

namespace Marketplace.Interfaces.Services
{
    public interface IPaymentInfoService
    {
        Task<int> SavePaymentInfo(PaymentInfoCreateDto paymentInfoDto);
        Task<int> UpdatePaymentInfo(PaymentInfoUpdateDto paymentInfoDto);
        Task DeletePaymentInfo(int idPaymentInfo);
        Task<List<PaymentInfoResponseDto>> GetAllPaymentInfos();
        Task<PaymentInfoResponseDto> GetPaymentInfoByIdAsync(int idPaymentInfo);
    }
}
