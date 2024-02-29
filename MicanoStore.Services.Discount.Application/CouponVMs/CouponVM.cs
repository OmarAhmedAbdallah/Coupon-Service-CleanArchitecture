namespace MicanoStore.Services.Discount.Application.CouponVMs
{
    public class CouponVM
    {
        public Guid Id { get; set; }
        public string? CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
