using System.ComponentModel.DataAnnotations;

namespace MicanoStore.Services.Discount.Domain.Entities;

public class Coupon : EntityBase
{
    [Required]
    public string? CouponCode { get; set; }
    [Required]
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}