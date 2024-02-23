using MicanoStore.Services.Discount.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace MicanoStore.Services.Discount.Infrastructure;

public class DiscountDbContext : DbContext
{
    public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
    {
    }

    public DbSet<Coupon> Coupons { get; set; }
}