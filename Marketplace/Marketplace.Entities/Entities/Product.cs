using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Entities.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set;}

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [StringLength(1000)]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; }


        [Required]
        public int SellerId { get; set; }
        public virtual Seller ?Seller { get; set; }

        public virtual ICollection<ProductReview> ?Reviews { get; set; }

        public virtual ICollection<OrderItem> ?OrderItems { get; set; }

        public Product(int sellerId, string name, string description, string imageUrl, decimal price, int stock, DateTime createdAt, DateTime updatedAt)
        {
            SellerId = sellerId;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
            Stock = stock;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
