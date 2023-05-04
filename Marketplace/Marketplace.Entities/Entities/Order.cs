using Marketplace.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Entities.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrder { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [StringLength(30)]
        public string State { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        [Required]
        [StringLength(9)]
        public string ZipCode { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<OrderItem> ?Items { get; set; }

        public Order(int idOrder, int userId, decimal totalPrice, DateTime createdAt, DateTime updatedAt, Status status, string address, string city, string state, string country, string zipCode)
        {
            IdOrder = idOrder;
            UserId = userId;
            TotalPrice = totalPrice;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Status = status;
            Address = address;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
    }
}
