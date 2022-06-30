using System.ComponentModel.DataAnnotations;

namespace MyO_Backend.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public User User { get; set; }        
        public int UserId { get; set; }        
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public float TotalAmount { get; set; }
        public bool IsPurchase { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<OrderDetail> OrderDetail { get; set; }

    }
}
