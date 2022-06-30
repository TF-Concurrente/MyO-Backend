using System.ComponentModel.DataAnnotations;

namespace MyO_Backend.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
