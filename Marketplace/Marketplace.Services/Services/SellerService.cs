using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;

namespace Marketplace.Services.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository; 
        public SellerService(ISellerRepository sellerRepository) 
        { 
            _sellerRepository = sellerRepository;
        }
        public Task DeleteSeller(int idSeller)
        {
            var request = _sellerRepository.DeleteSeller(idSeller);
            return request;
        }

        public async Task<List<SellerResponseDto>> GetAllSellers()
        {
            var sellers = await _sellerRepository.GetAllSellers();
            var sellerResponseDtos = new List<SellerResponseDto>();

            foreach(var seller in sellers) 
            {
                sellerResponseDtos.Add(new SellerResponseDto
                {
                    IDSeller = seller.IDSeller,
                    CompanyName = seller.CompanyName,
                    CNPJ = seller.CNPJ,
                    TaxId = seller.TaxId,
                    UserId = seller.UserId
                });
            }

            return sellerResponseDtos;
        }

        public async Task<SellerResponseDto> GetSellerByIdAsync(int idSeller)
        {
            var seller = await _sellerRepository.GetSellerByIdAsync(idSeller);

            if(seller != null)
            {
                var sellerResponseDto = new SellerResponseDto
                {
                    IDSeller = seller.IDSeller,
                    CompanyName = seller.CompanyName,
                    CNPJ = seller.CNPJ,
                    TaxId = seller.TaxId,
                    UserId = seller.UserId
                };

                return sellerResponseDto;
            }

            return null;
        }

        public async Task<int> SaveSeller(SellerCreateDto sellerDto)
        {
            var seller = new Seller(sellerDto.UserId, sellerDto.CompanyName, sellerDto.CNPJ, sellerDto.TaxId);
            var id = await _sellerRepository.SaveSeller(seller);

            return id;
        }

        public async Task<int> UpdateSeller(SellerUpdateDto sellerDto)
        {
            var seller = await _sellerRepository.GetSellerByIdAsync(sellerDto.IDSeller);

            if(seller != null)
            {
                if(sellerDto.CompanyName != null) seller.CompanyName = sellerDto.CompanyName;
                if(sellerDto.CNPJ != null) seller.CNPJ = sellerDto.CNPJ;
                if(sellerDto.TaxId != null) seller.TaxId = seller.TaxId;

                int id = await _sellerRepository.UpdateSeller(seller);

                return id;
            }

            return 0;
        }
    }
}
