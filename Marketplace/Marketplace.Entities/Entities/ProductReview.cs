using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Entities.Entities
{
    public class ProductReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProductReview { get; set; }

        [Required]
        [Range(0, 10)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public ProductReview(int idProductReview, int userId, int productId, int rating, string comment, DateTime createdAt, DateTime updatedAt)
        {
            IdProductReview = idProductReview;
            UserId = userId;
            ProductId = productId;
            Rating = rating;
            Comment = comment;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
