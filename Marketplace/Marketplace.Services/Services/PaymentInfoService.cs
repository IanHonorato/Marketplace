using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;

namespace Marketplace.Services.Services
{
    public class PaymentInfoService : IPaymentInfoService
    {
        private readonly IPaymentInfoRepository _paymentInfoRepository;

        public PaymentInfoService(IPaymentInfoRepository paymentInfoRepository)
        {
            _paymentInfoRepository = paymentInfoRepository;
        }

        public Task DeletePaymentInfo(int idPaymentInfo)
        {
            var request = _paymentInfoRepository.DeletePaymentInfo(idPaymentInfo);
            return request;
        }

        public async Task<List<PaymentInfoResponseDto>> GetAllPaymentInfos()
        {
            var paymentInfos = await _paymentInfoRepository.GetAllPaymentInfo();
            var paymentInfoResponseDtos = new List<PaymentInfoResponseDto>();

            foreach (var paymentInfo in paymentInfos)
            {
                paymentInfoResponseDtos.Add(new PaymentInfoResponseDto
                {
                    IdPaymentInfo = paymentInfo.IdPaymentInfo,
                    Type = paymentInfo.Type,
                    CardNumber = paymentInfo.CardNumber,
                    ExpirationDate = paymentInfo.ExpirationDate,
                    Cvv = paymentInfo.Cvv,
                    UserId = paymentInfo.UserId
                });
            }

            return paymentInfoResponseDtos;
        }

        public async Task<PaymentInfoResponseDto> GetPaymentInfoByIdAsync(int idPaymentInfo)
        {
            var paymentInfo = await _paymentInfoRepository.GetPaymentInfoByIdAsync(idPaymentInfo);

            if(paymentInfo != null)
            {
                var paymentInfoDto = new PaymentInfoResponseDto
                {
                    IdPaymentInfo = paymentInfo.IdPaymentInfo,
                    Type = paymentInfo.Type,
                    CardNumber = paymentInfo.CardNumber,
                    ExpirationDate = paymentInfo.ExpirationDate,
                    Cvv = paymentInfo.Cvv,
                    UserId = paymentInfo.UserId
                };

                return paymentInfoDto;
            }

            return null;
        }

        public async Task<int> SavePaymentInfo(PaymentInfoCreateDto paymentInfoDto)
        {
            var paymentInfo = new PaymentInfo(paymentInfoDto.UserId, paymentInfoDto.Type, paymentInfoDto.CardNumber, paymentInfoDto.ExpirationDate, paymentInfoDto.Cvv);
            var id = await _paymentInfoRepository.SavePaymentInfo(paymentInfo);

            return id;
        }

        public async Task<int> UpdatePaymentInfo(PaymentInfoUpdateDto paymentInfoDto)
        {
            var paymentInfo = await _paymentInfoRepository.GetPaymentInfoByIdAsync(paymentInfoDto.idPaymentInfo);

            if(paymentInfo != null)
            {
                if (paymentInfoDto.Type != null) paymentInfo.Type = paymentInfoDto.Type;
                if (paymentInfoDto.CardNumber != null) paymentInfo.CardNumber = paymentInfoDto.CardNumber;
                if (paymentInfoDto.ExpirationDate != null) paymentInfo.ExpirationDate = paymentInfoDto.ExpirationDate;
                if (paymentInfoDto.Cvv != null) paymentInfo.Cvv = paymentInfoDto.Cvv;
                if (paymentInfoDto.UserId != 0) paymentInfo.UserId = paymentInfoDto.UserId;

                int id = await _paymentInfoRepository.UpdatePaymentInfo(paymentInfo);

                return id;
            };

            return 0;
        }
    }
}
