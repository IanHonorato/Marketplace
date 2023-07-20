using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Entities.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDUser { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(14)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordSalt { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(9)]
        public string ZipCode { get; set; }

        [Required]
        public bool IsSeller { get; set; }

        [Required]
        public DateTime CreatedAt  { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<PaymentInfo> ?PaymentInfos { get; set; }

        public ICollection<Order> ?Orders { get; set; }

        public virtual ICollection<ProductReview> ?Reviews { get; set; }

        public virtual Seller ?Seller { get; set; }

        public User() { }

        public User(string name, string cpf, string email, string passwordHash, string passwordSalt, string phone, string address, string city, string state, 
            string country, string zipCode, bool isSeller, DateTime createdAt, DateTime updatedAt)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            IsSeller = isSeller;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
