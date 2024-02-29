namespace MicanoStore.Services.Discount.Application.CouponDTOs
{
    public class CouponDTO
    {
        public string? CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
