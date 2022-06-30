using System.ComponentModel.DataAnnotations;

namespace MyO_Backend.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public bool IsPurchase { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public ICollection<OrderDetailViewModel> OrderDetail { get; set; }
    }
}
