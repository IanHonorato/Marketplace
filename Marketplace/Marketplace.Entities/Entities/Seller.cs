using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Entities.Entities
{
    public class Seller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDSeller { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(25)]
        public string CNPJ { get; set; }

        [Required]
        [StringLength(20)]
        public string TaxId { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User ?User { get; set; }

        public virtual ICollection<Product> ?Products { get; set; }

        public Seller(int iDSeller, int userId, string companyName, string cNPJ, string taxId)
        {
            IDSeller = iDSeller;
            UserId = userId;
            CompanyName = companyName;
            CNPJ = cNPJ;
            TaxId = taxId;
        }
    }
}
