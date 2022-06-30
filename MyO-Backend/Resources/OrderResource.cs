namespace MyO_Backend.Resources
{
    public class OrderResource
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }        
        public DateTime CreatedAt { get; set; }        
        public float TotalAmount { get; set; }
        public bool IsPurchase { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<OrderDetailResource> OrderDetail { get; set; }
    }
}
