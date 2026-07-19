namespace Discount.gRPC.Models
{
    public class Coupons
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Amount { get; set; } 
    }
}
