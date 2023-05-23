namespace Marketplace.Models.Dto
{
    public class SellerDto
    {
        public string CompanyName { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
    public class SellerCreateDto : SellerDto
    {
    }

    public class SellerUpdateDto : SellerDto
    {
        public int IDSeller { get; set; }
    }

    public class SellerResponseDto : SellerDto
    {
        public int IDSeller { get; set; }
    }
}