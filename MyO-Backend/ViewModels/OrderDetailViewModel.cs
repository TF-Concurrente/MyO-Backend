using System.ComponentModel.DataAnnotations;

namespace MyO_Backend.ViewModels
{
    public class OrderDetailViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Amount { get; set; }

    }
}
