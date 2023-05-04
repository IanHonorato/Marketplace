using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Entities.Entities
{
    public class PaymentInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaymentInfo { get; set; }

        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        [Required]
        [StringLength(20)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string ExpirationDate { get; set; }

        [Required]
        [StringLength(4)]
        public string Cvv { get; set;}

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public PaymentInfo(int idPaymentInfo, int userId, string type, string cardNumber, string expirationDate, string cvv)
        {
            IdPaymentInfo = idPaymentInfo;
            UserId = userId;
            Type = type;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            Cvv = cvv;
        }
    }
}
