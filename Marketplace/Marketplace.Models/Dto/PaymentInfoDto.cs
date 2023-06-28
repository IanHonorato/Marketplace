namespace Marketplace.Models.Dto
{
    public class PaymentInfoDto
    {
        public string Type { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
        public string Cvv { get; set; } = string.Empty;
        public int UserId { get; set; }
    }

    public class PaymentInfoCreateDto : PaymentInfoDto { }

    public class PaymentInfoUpdateDto : PaymentInfoDto 
    { 
        public int idPaymentInfo { get; set; }
    }
    public class PaymentInfoResponseDto : PaymentInfoDto 
    { 
        public int IdPaymentInfo { get; set; }
    }
}
