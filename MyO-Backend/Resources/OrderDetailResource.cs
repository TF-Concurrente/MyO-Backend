namespace MyO_Backend.Resources
{
    public class OrderDetailResource
    {
        public int OrderDetailId { get; set; }
        public ProductResource Product { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public float TotalAmount { get; set; }
    }
}
