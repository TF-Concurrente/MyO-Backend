using System.ComponentModel.DataAnnotations;

namespace MyO_Backend.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int OrderId { get; set; }       
        public Product Product { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Amount  { get; set; }
        public float TotalAmount { get; set; }
    }
}
