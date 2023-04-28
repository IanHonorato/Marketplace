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
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string PaymentInfo  { get; set; }

        public User(int idUser, string name, string email, string passwordHash, string address, string paymentInfo)
        {
            IDUser = idUser;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Address = address;
            PaymentInfo = paymentInfo;
        }
    }
}
